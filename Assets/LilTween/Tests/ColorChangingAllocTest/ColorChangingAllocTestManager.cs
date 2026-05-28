using System.Linq;
using DG.Tweening;
using LilTween.ChangeColor;
using LilTween.Core;
using Plugins.Demigiant.DOTween.Modules;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

namespace LilTween.Tests.ColorChangingAllocTest
{
    public class ColorChangingAllocTestManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _duration;
        [SerializeField] private float _delay;
        [SerializeField] private Color _targetLilTweenColor;
        [SerializeField] private Color _targetDoTweenColor;

        [Header("References")] 
        [SerializeField] private Image[] _lilTweenObjects;
        [SerializeField] private Image[] _doTweenObjects;

        private readonly ProfilerMarker _lilTweenTestMarker = new("[ColorChangingAllocTestManager] LilTween marker");
        private readonly ProfilerMarker _doTweenTestMarker = new("[ColorChangingAllocTestManager] DOTween marker");

        private Color _defaultLilTweenColor;
        private Color _defaultDoTweenColor;

        private void Awake()
        {
            DOTween.Init();
            _defaultLilTweenColor = _lilTweenObjects.First().color;
            _defaultDoTweenColor = _doTweenObjects.First().color;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeColor();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Reset();
            }
        }

        private void ChangeColor()
        {
            _lilTweenTestMarker.Begin();
            for (var i = 0; i < _lilTweenObjects.Length; i++)
            {
                var item = _lilTweenObjects[i];
                item.ChangeColor(_targetLilTweenColor, _duration).WithDelay(_delay * i);
            }
            _lilTweenTestMarker.End();

            _doTweenTestMarker.Begin();
            for (var i = 0; i < _doTweenObjects.Length; i++)
            {
                var item = _doTweenObjects[i];
                item.DOColor(_targetDoTweenColor, _duration).SetDelay(_delay * i);
            }
            _doTweenTestMarker.End();

            Profiler.enabled = false;
        }

        private void Reset()
        {
            foreach (var item in _lilTweenObjects) item.color = _defaultLilTweenColor;
            foreach (var item in _doTweenObjects) item.color = _defaultDoTweenColor;
            Profiler.enabled = true;
        }
    }
}