using System;
using System.Collections.Generic;
using LilTween.ChangeCanvasGroupAlpha;
using LilTween.ChangeColor;
using LilTween.ChangeGraphicAlpha;
using LilTween.MoveRect;
using LilTween.ScaleRect;
using LilTween.SimpleRotateRect;
using UnityEngine;

namespace LilTween.Core
{
    public class LilTweenSingleton : MonoBehaviour
    {
        private const int POOL_CAPACITY = 64;

        public static LilTweenSingleton Instance { get; private set; }

        public readonly Func<float, float> EaseLinearFunc = EaseLinear;
        public readonly Func<float, float> EaseOutQuadFunc = EaseOutQuad;
        public readonly Func<float, float> EaseInQuadFunc = EaseInQuad;

        // RULE: If you add a new tween type, don't forget to update this
        private static readonly Dictionary<TweenType, Func<Tween>> Constructors = new()
        {
            { TweenType.MoveRect, () => new MoveRectTween() },
            { TweenType.SimpleRotateRect, () => new SimpleRotateRectTween() },
            { TweenType.ScaleRect, () => new ScaleRectTween() },
            { TweenType.ChangeColor, () => new ChangeColorTween() },
            { TweenType.ChangeGraphicAlpha, () => new ChangeGraphicAlphaTween() },
            { TweenType.ChangeCanvasGroup, () => new ChangeCanvasGroupTween() }
        };

        public List<Tween> Tweens;
        private readonly Dictionary<TweenType, Queue<Tween>> _pool = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                foreach (var (tweenType, constructor) in Constructors)
                {
                    var queue = new Queue<Tween>(POOL_CAPACITY);

                    for (var i = 0; i < POOL_CAPACITY; i++)
                    {
                        queue.Enqueue(constructor.Invoke());
                    }

                    _pool[tweenType] = queue;
                }

                Tweens = new List<Tween>(POOL_CAPACITY * Constructors.Count);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;

            for (var i = Tweens.Count - 1; i >= 0; i--)
            {
                var tween = Tweens[i];
                if (!tween.Active)
                {
                    Tweens.RemoveAt(i);
                    continue;
                }

                tween.Elapsed += deltaTime;
                var progress = Mathf.Clamp01(tween.Elapsed / tween.Duration);
                var easedProgress = tween.Ease(progress);
                tween.Update(easedProgress);

                if (progress >= 1f)
                {
                    tween.Active = false;
                    tween.OnComplete?.Invoke();
                    tween.Clear();
                    _pool[tween.TweenType].Enqueue(tween);
                    Tweens.RemoveAt(i);
                }
                else
                {
                    Tweens[i] = tween;
                }
            }
        }

        public Tween GetTween(TweenType tweenType)
        {
            var queue = _pool[tweenType];
            return queue.Count > 0 ? queue.Dequeue() : Constructors[tweenType].Invoke();
        }

        private static float EaseLinear(float t) => t;
        private static float EaseOutQuad(float t) => 1f - (1f - t) * (1f - t);
        private static float EaseInQuad(float t) => t * t;
    }
}