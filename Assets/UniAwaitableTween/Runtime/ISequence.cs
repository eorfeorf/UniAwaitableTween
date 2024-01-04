using System.Threading;
using Cysharp.Threading.Tasks;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// シーケンスを実現させるための最低限の機能.
    /// </summary>
    public interface ISequence
    {
        public UniTask UpdateAsync(CancellationToken ct);
    }
}