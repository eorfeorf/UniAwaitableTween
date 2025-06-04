using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// 回転シーケンス.
    /// </summary>
    public sealed class BehaviourRotate : BehaviourBase<Quaternion>
    {
        private readonly Transform _origin;

        public BehaviourRotate(Transform origin, Quaternion end, float duration, bool useUnscaledTime)
            : base(origin.rotation, end,
                useUnscaledTime ? Time.unscaledTime : Time.time,
                (useUnscaledTime ? Time.unscaledTime : Time.time) + duration,
                useUnscaledTime)
        {
            _origin = origin;
        }

        protected override void UpdateLerp(Quaternion start, Quaternion end, float t)
        {
            _origin.rotation = Quaternion.Lerp(start, end, t);
        }
    }
}
