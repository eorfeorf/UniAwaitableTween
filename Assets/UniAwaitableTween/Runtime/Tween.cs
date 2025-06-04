using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// Tweenアクセスクラス.
    /// </summary>
    public static class Tween
    {
        /// <summary>
        /// Transform.Position
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="offset">移動させる距離.</param>
        /// <param name="duration"></param>
        /// <param name="ct"></param>
        public static async UniTask Move(Transform origin, Vector3 offset, float duration, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new BehaviourMove(origin, offset, duration), ct);
        }

        /// <summary>
        /// Transform.Scale
        /// </summary>
        public static async UniTask Scale(Transform origin, Vector3 end, float duration, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new BehaviourScale(origin, end, duration), ct);
        }

        /// <summary>
        /// Transform.Rotation
        /// </summary>
        public static async UniTask Rotate(Transform origin, Quaternion end, float duration, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new BehaviourRotate(origin, end, duration), ct);
        }
        
        /// <summary>
        /// カラーフェード.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="end"></param>
        /// <param name="duration"></param>
        /// <param name="ct"></param>
        public static async UniTask ColorFade(Material origin, Color end, float duration, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new BehaviourColor(origin, end, duration), ct);
        }

        /// <summary>
        /// Executes tweens sequentially.
        /// </summary>
        public static async UniTask Sequence(IEnumerable<IBehaviour> behaviours, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new TweenSequence(behaviours), ct);
        }

        /// <summary>
        /// Executes tweens concurrently.
        /// </summary>
        public static async UniTask Parallel(IEnumerable<IBehaviour> behaviours, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new TweenParallel(behaviours), ct);
        }
    }

    /// <summary>
    /// Transform拡張.
    /// </summary>
    public static class UnityExtension
    {
        /// <summary>
        /// Transform.Position
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="offset"></param>
        /// <param name="duration"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public static async UniTask<Transform> Move(this Transform origin, Vector3 offset, float duration, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new BehaviourMove(origin, offset, duration), ct);
            return origin;
        }

        /// <summary>
        /// Transform.Scale
        /// </summary>
        public static async UniTask<Transform> Scale(this Transform origin, Vector3 target, float duration, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new BehaviourScale(origin, target, duration), ct);
            return origin;
        }

        /// <summary>
        /// Transform.Rotate
        /// </summary>
        public static async UniTask<Transform> Rotate(this Transform origin, Quaternion target, float duration, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new BehaviourRotate(origin, target, duration), ct);
            return origin;
        }
    }
}