using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    public class SequenceColor : SequenceBase<Color>
    {
        private Color _color;
        
        public SequenceColor(ref Color start, Color target, float duration)
        {
            _color = start;
            Initialize(start, target, Time.time, Time.time + duration);
        }

        protected override void UpdateLerp(Color start, Color end, float t)
        {
            _color = Color.Lerp(start, end, t);
        }
    }
}