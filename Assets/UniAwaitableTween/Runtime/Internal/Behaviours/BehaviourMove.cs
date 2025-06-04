using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// 移動シーケンス.
    /// </summary>
    public sealed class BehaviourMove : BehaviourBase<Vector3>
    {
        private readonly Transform _origin;

        public BehaviourMove(Transform origin, Vector3 value, float duration, bool useUnscaledTime)
            : base(origin.position, origin.position + value,
                useUnscaledTime ? Time.unscaledTime : Time.time,
                (useUnscaledTime ? Time.unscaledTime : Time.time) + duration,
                useUnscaledTime)
        {
            _origin = origin;
        }

        protected override void UpdateLerp(Vector3 start, Vector3 end, float t)
        {
            _origin.position = Vector3.Lerp(start, end, t);
        }
    }
}