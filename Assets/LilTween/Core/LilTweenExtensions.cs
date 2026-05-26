using System;

namespace LilTween.Core
{
    public static class LilTweenExtensions
    {
        public static Tween WithDelay(this Tween tween, float delay)
        {
            tween.Elapsed -= delay;
            return tween;
        }

        public static Tween AddOnComplete(this Tween tween, Action onComplete)
        {
            tween.OnComplete = onComplete;
            return tween;
        }

        public static Tween WithCustomEase(this Tween tween, Func<float, float> ease)
        {
            tween.Ease = ease;
            return tween;
        }

        public static void SetTween(Tween tween, float duration)
        {
            tween.Duration = duration;
            tween.Active = true;
            tween.Ease = LilTweenSingleton.Instance.EaseLinearFunc;
        }
    }
}