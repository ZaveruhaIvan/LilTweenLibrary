using LilTween.Core;
using UnityEngine;

namespace LilTween.ScaleRect
{
    public class ScaleRectTween : Tween
    {
        public override TweenType TweenType => TweenType.ScaleRect;
        public RectTransform Target { get; set; }
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }

        public override void Update(float progress)
        {
            Target.localScale = Vector3.LerpUnclamped(From, To, progress);
        }

        public override void Clear()
        {
            base.Clear();
            Target = null;
        }
    }
}