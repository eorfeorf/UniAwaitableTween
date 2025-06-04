using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// ローカル移動シーケンス.
    /// </summary>
    public sealed class BehaviourMoveLocal : BehaviourBase<Vector3>
    {
        private readonly Transform _origin;

        public BehaviourMoveLocal(Transform origin, Vector3 value, float duration)
            : base(origin.localPosition, origin.localPosition + value, Time.time, Time.time + duration)
        {
            _origin = origin;
        }

        protected override void UpdateLerp(Vector3 start, Vector3 end, float t)
        {
            _origin.localPosition = Vector3.Lerp(start, end, t);
        }
    }
}
