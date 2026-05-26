using LilTween.Core;
using UnityEngine;

namespace LilTween.ScaleRect
{
    public static class ScaleRectTweenExtensions
    {
        public static Tween ScaleRect(this LilTweenSingleton singleton, RectTransform target, Vector2 from, Vector2 to, float duration)
        {
            var tween = (ScaleRectTween)singleton.GetTween(TweenType.ScaleRect);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            singleton.Tweens.Add(tween);
            return tween;
        }
        
        public static Tween ScaleRect(this LilTweenSingleton singleton, RectTransform target, Vector2 to, float duration)
        {
            return ScaleRect(singleton, target, target.localScale, to, duration);
        }
        
        public static Tween ScaleRect(this RectTransform target, Vector2 from, Vector2 to, float duration)
        {
            var tween = (ScaleRectTween)LilTweenSingleton.Instance.GetTween(TweenType.ScaleRect);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            LilTweenSingleton.Instance.Tweens.Add(tween);
            return tween;
        }
        
        public static Tween ScaleRect(this RectTransform target, Vector2 to, float duration)
        {
            return ScaleRect(target, target.localScale, to, duration);
        }
    }
}