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
        /// <param name="target"></param>
        /// <param name="duration"></param>
        /// <param name="ct"></param>
        public static async UniTask Move(Transform origin, Vector3 target, float duration, CancellationToken ct = default)
        {
            await SequenceManager.PlayAsync(new SequenceMove(origin, target, duration), ct);
        }
        
        public static async UniTask ColorFade(Color color, Color target, float duration, CancellationToken ct = default)
        {
            await SequenceManager.PlayAsync(new SequenceColor(ref color, target, duration), ct);
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