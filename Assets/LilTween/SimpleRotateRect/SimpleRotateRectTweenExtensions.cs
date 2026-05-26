using LilTween.Core;
using UnityEngine;

namespace LilTween.SimpleRotateRect
{
    public static class SimpleRotateRectTweenExtensions
    {
        public static Tween RotateRect(this LilTweenSingleton singleton, RectTransform target, float angle, float duration)
        {
            var tween = (SimpleRotateRectTween)singleton.GetTween(TweenType.SimpleRotateRect);

            tween.Target = target;
            tween.From = target.localEulerAngles.z;
            tween.To = tween.From + angle;

            LilTweenExtensions.SetTween(tween, duration);

            singleton.Tweens.Add(tween);
            return tween;
        }
        
        public static Tween RotateRect(this RectTransform target, float angle, float duration)
        {
            var tween = (SimpleRotateRectTween)LilTweenSingleton.Instance.GetTween(TweenType.SimpleRotateRect);

            tween.Target = target;
            tween.From = target.localEulerAngles.z;
            tween.To = tween.From + angle;

            LilTweenExtensions.SetTween(tween, duration);

            LilTweenSingleton.Instance.Tweens.Add(tween);
            return tween;
        }
    }
}