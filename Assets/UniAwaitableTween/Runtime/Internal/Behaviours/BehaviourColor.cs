using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    public class BehaviourColor : BehaviourBase<Color>
    {
        private Material _material;
        
        public BehaviourColor(Material start, Color target, float duration)
        {
            _material = start;
            Initialize(_material.color, target, Time.time, Time.time + duration);
        }

        protected override void Lerp(Color start, Color end, float t)
        {
            _material.color = Color.Lerp(start, end, t);
        }
    }
}