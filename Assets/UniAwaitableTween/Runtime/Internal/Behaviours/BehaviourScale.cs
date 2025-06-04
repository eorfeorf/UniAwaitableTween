using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// 拡縮シーケンス.
    /// </summary>
    public sealed class BehaviourScale : BehaviourBase<Vector3>
    {
        private readonly Transform _origin;

        public BehaviourScale(Transform origin, Vector3 end, float duration, bool useUnscaledTime)
            : base(origin.localScale, end,
                useUnscaledTime ? Time.unscaledTime : Time.time,
                (useUnscaledTime ? Time.unscaledTime : Time.time) + duration,
                useUnscaledTime)
        {
            _origin = origin;
        }

        protected override void UpdateLerp(Vector3 start, Vector3 end, float t)
        {
            _origin.localScale = Vector3.Lerp(start, end, t);
        }
    }
}
