using LilTween.Core;
using UnityEngine;

namespace LilTween.SimpleRotateRect
{
    public class SimpleRotateRectTween : Tween
    {
        public override TweenType TweenType => TweenType.SimpleRotateRect;
        public RectTransform Target { get; set; }
        public float From { get; set; }
        public float To { get; set; }

        public override void Update(float progress)
        {
            var z = Mathf.Lerp(From, To, progress);
            Target.localRotation = Quaternion.Euler(0f, 0f, z);
        }

        public override void Clear()
        {
            base.Clear();
            Target = null;
        }
    }
}