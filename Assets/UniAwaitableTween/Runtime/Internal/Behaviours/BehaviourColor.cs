using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    public class BehaviourColor : BehaviourBase<Color>
    {
        private readonly Material _origin;
        
        public BehaviourColor(Material origin, Color value, float duration, bool useUnscaledTime)
            : base(origin.color, value,
                useUnscaledTime ? Time.unscaledTime : Time.time,
                (useUnscaledTime ? Time.unscaledTime : Time.time) + duration,
                useUnscaledTime)
        {
            _origin = origin;
        }

        protected override void UpdateLerp(Color start, Color end, float t)
        {
            _origin.color = Color.Lerp(start, end, t);
        }
    }
}