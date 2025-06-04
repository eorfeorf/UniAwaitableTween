using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// 回転シーケンス.
    /// </summary>
    public sealed class BehaviourRotate : BehaviourBase<Quaternion>
    {
        private readonly Transform _origin;

        public BehaviourRotate(Transform origin, Quaternion end, float duration, EasingType easing = EasingType.Linear)
            : base(origin.rotation, end, Time.time, Time.time + duration, easing)
        {
            _origin = origin;
        }

        protected override void UpdateLerp(Quaternion start, Quaternion end, float t)
        {
            _origin.rotation = Quaternion.Lerp(start, end, t);
        }
    }
}
