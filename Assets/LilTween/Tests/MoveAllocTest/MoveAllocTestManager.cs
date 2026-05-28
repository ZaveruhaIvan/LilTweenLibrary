using System.Collections.Generic;
using DG.Tweening;
using LilTween.Core;
using LilTween.MoveRect;
using Plugins.Demigiant.DOTween.Modules;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;

namespace LilTween.Tests.MoveAllocTest
{
    public class MoveAllocTestManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _duration;
        [SerializeField] private float _delay;
        [SerializeField] private float _targetPositionY;

        [Header("References")]
        [SerializeField] private RectTransform[] _lilTweenObjects;
        [SerializeField] private RectTransform[] _doTweenObjects;

        private readonly ProfilerMarker _lilTweenColorTestMarker = new("[MoveAllocTestManager] LilTween marker");
        private readonly ProfilerMarker _doTweenColorTestMarker = new("[MoveAllocTestManager] DOTween marker");
        private readonly Dictionary<RectTransform, Vector2> _lilTweenDefaultScreenPositions = new();
        private readonly Dictionary<RectTransform, Vector2> _doTweenDefaultScreenPositions = new();

        public void Awake()
        {
            DOTween.Init();
            foreach (var item in _lilTweenObjects) _lilTweenDefaultScreenPositions.Add(item, item.anchoredPosition);
            foreach (var item in _doTweenObjects) _doTweenDefaultScreenPositions.Add(item, item.anchoredPosition);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Move();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Reset();
            }
        }

        private void Move()
        {
            _lilTweenColorTestMarker.Begin();
            for (var i = 0; i < _lilTweenObjects.Length; i++)
            {
                var item = _lilTweenObjects[i];
                item.MoveRect(new Vector2(item.anchoredPosition.x, _targetPositionY), _duration).WithDelay(_delay * i);
            }
            _lilTweenColorTestMarker.End();
            
            _doTweenColorTestMarker.Begin();
            for (var i = 0; i < _doTweenObjects.Length; i++)
            {
                var item = _doTweenObjects[i];
                item.DOAnchorPos(new Vector2(item.anchoredPosition.x, -_targetPositionY), _duration).SetDelay(_delay * i);
            }
            _doTweenColorTestMarker.End();

            Profiler.enabled = false;
        }

        private void Reset()
        {
            foreach (var item in _lilTweenObjects) item.anchoredPosition = _lilTweenDefaultScreenPositions[item];
            foreach (var item in _doTweenObjects) item.anchoredPosition = _doTweenDefaultScreenPositions[item];
        }
    }
}