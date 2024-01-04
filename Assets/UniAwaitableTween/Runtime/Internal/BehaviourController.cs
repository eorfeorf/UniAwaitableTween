using System.Threading;
using Cysharp.Threading.Tasks;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// シーケンスを管理するクラス.
    /// </summary>
    public static class BehaviourController
    {
        public static async UniTask PlayAsync(IBehaviour behaviour, CancellationToken ct)
        {
            await behaviour.UpdateAsync(ct);
        }
    }
}