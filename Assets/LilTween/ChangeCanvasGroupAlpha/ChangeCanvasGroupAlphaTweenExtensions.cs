using LilTween.Core;
using UnityEngine;

namespace LilTween.ChangeCanvasGroupAlpha
{
    public static class ChangeCanvasGroupTweenExtensions
    {
        public static Tween ChangeAlpha(this LilTweenSingleton singleton, CanvasGroup target, float from, float to, float duration)
        {
            var tween = (ChangeCanvasGroupTween)singleton.GetTween(TweenType.ChangeCanvasGroup);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            singleton.Tweens.Add(tween);
            return tween;
        }        
        
        public static Tween ChangeAlpha(this CanvasGroup target, float from, float to, float duration)
        {
            var tween = (ChangeCanvasGroupTween)LilTweenSingleton.Instance.GetTween(TweenType.ChangeCanvasGroup);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            LilTweenSingleton.Instance.Tweens.Add(tween);
            return tween;
        }

        public static Tween ChangeAlpha(this CanvasGroup target, float to, float duration)
        {
            return ChangeAlpha(target, target.alpha, to, duration);
        }

        public static Tween ChangeAlpha(this LilTweenSingleton singleton, CanvasGroup target, float to, float duration)
        {
            return ChangeAlpha(singleton, target, target.alpha, to, duration);
        }
    }
}