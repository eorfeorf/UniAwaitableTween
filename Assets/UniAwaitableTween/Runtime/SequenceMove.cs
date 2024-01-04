using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// 移動シーケンス.
    /// </summary>
    public sealed class SequenceMove : SequenceBase<Vector3>
    {
        private readonly Transform _origin;

        public SequenceMove(Transform origin, Vector3 target, float duration)
        {
            _origin = origin;
            Initialize(origin.position, origin.position + target, Time.time, Time.time + duration);
        }

        protected override void UpdateLerp(Vector3 start, Vector3 end, float t)
        {
            _origin.position = Vector3.Lerp(start, end, t);
        }
    }
}