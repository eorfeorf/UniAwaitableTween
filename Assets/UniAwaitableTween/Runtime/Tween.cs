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
        /// <param name="end"></param>
        /// <param name="duration"></param>
        /// <param name="ct"></param>
        public static async UniTask Move(Transform origin, Vector3 end, float duration, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new BehaviourMove(origin, end, duration), ct);
        }
        
        public static async UniTask ColorFade(Material origin, Color end, float duration, CancellationToken ct = default)
        {
            await BehaviourController.PlayAsync(new BehaviourColor(origin, end, duration), ct);
        }
    }

    /// <summary>
    /// Transform拡張.
    /// </summary>
    public static class TransformExtension
    {
        /// <summary>
        /// Transform.Position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="duration"></param>
        /// <param name="onComplete"></param>
        /// <param name="onError"></param>
        /// <param name="onProgress"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        // public static async UniTask<Transform> Move(this Transform transform, Vector3 target, float duration, CancellationToken ct = default)
        // {
        //     await SequenceManager.PlayAsync(new SequenceMove(transform, target, duration), ct);
        //     return transform;
        // }
    }
}