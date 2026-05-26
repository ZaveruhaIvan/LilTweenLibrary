using System;

namespace LilTween.Core
{
    public abstract class Tween
    {
        public abstract TweenType TweenType { get; }
        public float Duration { get; set; }
        public float Elapsed { get; set; }
        public bool Active { get; set; }
        public Func<float, float> Ease { get; set; }
        public Action OnComplete { get; set; }

        public abstract void Update(float progress);

        public virtual void Clear()
        {
            Duration = 0;
            Elapsed = 0;
            Active = false;
            Ease = null;
            OnComplete = null;
        }
    }
}