using LilTween.Core;
using UnityEngine;

namespace LilTween.ChangeCanvasGroupAlpha
{
    public class ChangeCanvasGroupTween : Tween
    {
        public override TweenType TweenType => TweenType.ChangeCanvasGroup;
        public CanvasGroup Target { get; set; }
        public float From { get; set; }
        public float To { get; set; }

        public override void Update(float progress)
        {
            Target.alpha = Mathf.LerpUnclamped(From, To, progress);
        }

        public override void Clear()
        {
            base.Clear();
            Target = null;
        }
    }
}