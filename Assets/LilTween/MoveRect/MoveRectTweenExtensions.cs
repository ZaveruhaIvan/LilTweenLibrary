using LilTween.Core;
using UnityEngine;

namespace LilTween.MoveRect
{
    public static class MoveRectTweenExtensions
    {
        public static Tween MoveRect(this LilTweenSingleton singleton, RectTransform target, Vector2 from, Vector2 to, float duration)
        {
            var tween = (MoveRectTween)singleton.GetTween(TweenType.MoveRect);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            singleton.Tweens.Add(tween);
            return tween;
        }       
        
        public static Tween MoveRect(this RectTransform target, Vector2 from, Vector2 to, float duration)
        {
            var tween = (MoveRectTween)LilTweenSingleton.Instance.GetTween(TweenType.MoveRect);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            LilTweenSingleton.Instance.Tweens.Add(tween);
            return tween;
        }

        public static Tween MoveRect(this RectTransform target, Vector2 to, float duration)
        {
            return MoveRect(target, target.anchoredPosition, to, duration);
        }

        public static Tween MoveRect(this LilTweenSingleton singleton, RectTransform target, Vector2 to, float duration)
        {
            return MoveRect(singleton, target, target.anchoredPosition, to, duration);
        }
    }
}