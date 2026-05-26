using LilTween.Core;
using UnityEngine;
using UnityEngine.UI;

namespace LilTween.ChangeColor
{
    public class ChangeColorTween : Tween
    {
        public override TweenType TweenType => TweenType.ChangeColor;
        public Graphic Target { get; set; }
        public Color From { get; set; }
        public Color To { get; set; }

        public override void Update(float progress)
        {
            Target.color = Color.LerpUnclamped(From, To, progress);
        }

        public override void Clear()
        {
            base.Clear();
            Target = null;
        }
    }
}