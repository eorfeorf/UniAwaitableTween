using System;
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
            try
            {
                await behaviour.UpdateAsync(ct);
            }
            catch (OperationCanceledException)
            {
                behaviour.SetLerpT(1f);
            }
        }
    }
}