using LilTween.Core;
using UnityEngine.UI;

namespace LilTween.ChangeGraphicAlpha
{
    public static class ChangeGraphicAlphaTweenExtensions
    {
        public static Tween ChangeAlpha(this LilTweenSingleton singleton, Graphic target, float from, float to, float duration)
        {
            var tween = (ChangeGraphicAlphaTween)singleton.GetTween(TweenType.ChangeGraphicAlpha);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            singleton.Tweens.Add(tween);
            return tween;
        }

        public static Tween ChangeAlpha(this LilTweenSingleton singleton, Graphic target, float to, float duration)
        {
            return ChangeAlpha(singleton, target, target.color.a, to, duration);
        }
        
        public static Tween ChangeAlpha(this Graphic target, float from, float to, float duration)
        {
            var tween = (ChangeGraphicAlphaTween)LilTweenSingleton.Instance.GetTween(TweenType.ChangeGraphicAlpha);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            LilTweenSingleton.Instance.Tweens.Add(tween);
            return tween;
        }
        
        public static Tween ChangeAlpha(this Graphic target, float to, float duration)
        {
            return ChangeAlpha(target, target.color.a, to, duration);
        }
    }
}