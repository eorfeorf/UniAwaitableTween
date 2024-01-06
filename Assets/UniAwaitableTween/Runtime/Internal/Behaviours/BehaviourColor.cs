using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    public class BehaviourColor : BehaviourBase<Color>
    {
        private readonly Material _origin;
        
        public BehaviourColor(Material origin, Color value, float duration)
            : base(origin.color, value, Time.time, Time.time + duration)
        {
            _origin = origin;
        }

        protected override void UpdateLerp(Color start, Color end, float t)
        {
            _origin.color = Color.Lerp(start, end, t);
        }
    }
}