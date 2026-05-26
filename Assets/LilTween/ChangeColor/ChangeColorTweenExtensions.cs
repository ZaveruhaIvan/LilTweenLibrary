using LilTween.Core;
using UnityEngine;
using UnityEngine.UI;

namespace LilTween.ChangeColor
{
    public static class ChangeColorTweenExtensions
    {
        public static Tween ChangeColor(this LilTweenSingleton singleton, Graphic target, Color from, Color to, float duration)
        {
            var tween = (ChangeColorTween)singleton.GetTween(TweenType.ChangeColor);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            singleton.Tweens.Add(tween);
            return tween;
        }        
        
        public static Tween ChangeColor(this Graphic target, Color from, Color to, float duration)
        {
            var tween = (ChangeColorTween)LilTweenSingleton.Instance.GetTween(TweenType.ChangeColor);

            tween.Target = target;
            tween.From = from;
            tween.To = to;

            LilTweenExtensions.SetTween(tween, duration);

            LilTweenSingleton.Instance.Tweens.Add(tween);
            return tween;
        }
        
        public static Tween ChangeColor(this Graphic target, Color to, float duration)
        {
            return ChangeColor(target, target.color, to, duration);
        }

        public static Tween ChangeColor(this LilTweenSingleton singleton, Graphic target, Color to, float duration)
        {
            return ChangeColor(singleton, target, target.color, to, duration);
        }
    }
}