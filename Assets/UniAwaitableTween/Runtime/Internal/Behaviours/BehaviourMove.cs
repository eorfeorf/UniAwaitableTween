using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// 移動シーケンス.
    /// </summary>
    public sealed class BehaviourMove : BehaviourBase<Vector3>
    {
        private readonly Transform _origin;

        public BehaviourMove(Transform origin, Vector3 value, float duration)
            : base(origin.position, origin.position + value, Time.time, Time.time + duration)
        {
            _origin = origin;
        }

        protected override void UpdateLerp(Vector3 start, Vector3 end, float t)
        {
            _origin.position = Vector3.Lerp(start, end, t);
        }
    }
}