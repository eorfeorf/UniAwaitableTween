using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    public class BehaviourColor : BehaviourBase<Color>
    {
        private Color _color;
        
        public BehaviourColor(Color start, Color target, float duration)
        {
            _color = start;
            Initialize(start, target, Time.time, Time.time + duration);
        }

        protected override void Lerp(Color start, Color end, float t)
        {
            _color = Color.Lerp(start, end, t);
        }
    }
}