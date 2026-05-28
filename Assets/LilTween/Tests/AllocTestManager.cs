using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using LilTween.ChangeColor;
using LilTween.MoveRect;
using Plugins.Demigiant.DOTween.Modules;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;
using Button = UnityEngine.UI.Button;

namespace LilTween.Tests
{
    public class AllocTestManager : MonoBehaviour
    {
        [Header("Settings")] [SerializeField] private int _testObjectAmount;
        [SerializeField] private Color _finalColor;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _destroyTestObjectsTimer;
        [SerializeField] private float _executionTimer;

        [Header("Links")] [SerializeField] private TestObjectView _testObjectPrefab;
        [SerializeField] private Button _colorTestButton;
        [SerializeField] private Button _movementTestButton;
        [SerializeField] private Button _quitAppButton;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private RectTransform _displayCanvasRect;
        [SerializeField] private RectTransform _colorTestParent;
        [SerializeField] private RectTransform _movementTestParent;

        private readonly ProfilerMarker _doTweenColorTestMarker = new("[ZID] [ColorTest] [DOTween]");
        private readonly ProfilerMarker _lilTweenColorTestMarker = new("[ZID] [ColorTest] [LilTween]");
        private readonly ProfilerMarker _doTweenMovementTestMarker = new("[ZID] [MovementTest] [DOTween]");
        private readonly ProfilerMarker _lilTweenMovementTestMarker = new("[ZID] [MovementTest] [LilTween]");

        public void Awake()
        {
            DOTween.Init();
        }

        private void Start()
        {
            _colorTestButton.onClick.AddListener(() => StartCoroutine(RunColorAllocTest()));
            _movementTestButton.onClick.AddListener(() => StartCoroutine(RunMovementAllocTest()));
            _quitAppButton.onClick.AddListener(Application.Quit);
        }

        private IEnumerator RunColorAllocTest()
        {
            Profiler.enabled = true;

            var doTweenList = new List<TestObjectView>();
            var lilTweenList = new List<TestObjectView>();
            var canvasSize = _displayCanvasRect.rect.size;

            for (var i = 0; i < _testObjectAmount; i++)
            {
                doTweenList.Add(InstantiateTestObject(canvasSize, _colorTestParent, false));
                lilTweenList.Add(InstantiateTestObject(canvasSize, _colorTestParent, true));
            }

            yield return new WaitForSeconds(_executionTimer);

            _doTweenColorTestMarker.Begin();
            foreach (var item in doTweenList) item.Image.DOColor(_finalColor, _animationDuration);
            _doTweenColorTestMarker.End();

            _lilTweenColorTestMarker.Begin();
            foreach (var item in lilTweenList) item.Image.ChangeColor(_finalColor, _animationDuration);
            _lilTweenColorTestMarker.End();
            Profiler.enabled = false;

            yield return new WaitForSeconds(_destroyTestObjectsTimer);

            foreach (Transform item in _colorTestParent) Destroy(item.gameObject);
        }

        private IEnumerator RunMovementAllocTest()
        {
            Profiler.enabled = true;

            var doTweenList = new List<TestObjectView>();
            var lilTweenList = new List<TestObjectView>();
            var canvasSize = _displayCanvasRect.rect.size;

            for (var i = 0; i < _testObjectAmount; i++)
            {
                doTweenList.Add(InstantiateTestObject(canvasSize, _movementTestParent, false));
                lilTweenList.Add(InstantiateTestObject(canvasSize, _movementTestParent, true));
            }

            yield return new WaitForSeconds(_executionTimer);

            _doTweenMovementTestMarker.Begin();
            foreach (var item in doTweenList) item.RectTransform.DOAnchorPos(GetRandomScreenPosition(canvasSize), _animationDuration);
            _doTweenMovementTestMarker.End();

            _lilTweenMovementTestMarker.Begin();
            foreach (var item in lilTweenList) item.RectTransform.MoveRect(GetRandomScreenPosition(canvasSize), _animationDuration);
            _lilTweenMovementTestMarker.End();
            Profiler.enabled = false;

            yield return new WaitForSeconds(_destroyTestObjectsTimer);

            foreach (Transform item in _movementTestParent) Destroy(item.gameObject);
        }

        private TestObjectView InstantiateTestObject(Vector2 canvasSize, RectTransform parent, bool isLilTween)
        {
            var testObj = Instantiate(_testObjectPrefab, parent);
            var randomPos = GetRandomScreenPosition(canvasSize);

            testObj.Set(isLilTween);
            testObj.RectTransform.anchoredPosition = randomPos;
            return testObj;
        }

        private static Vector2 GetRandomScreenPosition(Vector2 canvasSize)
        {
            return new Vector2(Random.Range(-canvasSize.x / 2 + 50, canvasSize.x / 2 - 50), Random.Range(-canvasSize.y / 2 + 50, canvasSize.y / 2 - 50));
        }
    }
}