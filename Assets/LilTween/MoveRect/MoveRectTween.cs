using LilTween.Core;
using UnityEngine;

namespace LilTween.MoveRect
{
    public class MoveRectTween : Tween
    {
        public override TweenType TweenType => TweenType.MoveRect;
        public RectTransform Target { get; set; }
        public Vector2 From { get; set; }
        public Vector2 To { get; set; }

        public override void Update(float progress)
        {
            Target.anchoredPosition = Vector2.LerpUnclamped(From, To, progress);
        }

        public override void Clear()
        {
            base.Clear();
            Target = null;
        }
    }
}