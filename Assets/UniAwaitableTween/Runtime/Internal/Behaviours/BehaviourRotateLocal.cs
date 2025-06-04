using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// ローカル回転シーケンス.
    /// </summary>
    public sealed class BehaviourRotateLocal : BehaviourBase<Quaternion>
    {
        private readonly Transform _origin;

        public BehaviourRotateLocal(Transform origin, Quaternion end, float duration)
            : base(origin.localRotation, end, Time.time, Time.time + duration)
        {
            _origin = origin;
        }

        protected override void UpdateLerp(Quaternion start, Quaternion end, float t)
        {
            _origin.localRotation = Quaternion.Lerp(start, end, t);
        }
    }
}
