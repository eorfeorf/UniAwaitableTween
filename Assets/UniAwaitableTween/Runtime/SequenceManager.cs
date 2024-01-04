using System.Threading;
using Cysharp.Threading.Tasks;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// シーケンスを管理するクラス.
    /// </summary>
    public static class SequenceManager
    {
        public static async UniTask PlayAsync(ISequence sequence, CancellationToken ct)
        {
            await sequence.UpdateAsync(ct);
        }
    }
}