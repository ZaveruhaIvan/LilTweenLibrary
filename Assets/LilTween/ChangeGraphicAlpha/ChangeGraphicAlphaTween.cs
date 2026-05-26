using LilTween.Core;
using UnityEngine;
using UnityEngine.UI;

namespace LilTween.ChangeGraphicAlpha
{
    public class ChangeGraphicAlphaTween : Tween
    {
        public override TweenType TweenType => TweenType.ChangeGraphicAlpha;
        public Graphic Target { get; set; }
        public float From { get; set; }
        public float To { get; set; }

        public override void Update(float progress)
        {
            var color = Target.color;
            color.a = Mathf.LerpUnclamped(From, To, progress);
            Target.color = color;
        }

        public override void Clear()
        {
            base.Clear();
            Target = null;
        }
    }
}