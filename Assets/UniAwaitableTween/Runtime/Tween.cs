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
    }
}