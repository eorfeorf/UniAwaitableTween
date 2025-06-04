using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// Executes multiple <see cref="IBehaviour"/> instances sequentially.
    /// </summary>
    public sealed class TweenSequence : IBehaviour
    {
        private readonly IBehaviour[] _behaviours;

        public TweenSequence(IEnumerable<IBehaviour> behaviours)
        {
            _behaviours = behaviours is IBehaviour[] array ? array : new List<IBehaviour>(behaviours).ToArray();
        }

        public async UniTask UpdateAsync(CancellationToken ct)
        {
            foreach (var behaviour in _behaviours)
            {
                await BehaviourController.PlayAsync(behaviour, ct);
            }
        }

        public void SetLerpT(float t)
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.SetLerpT(t);
            }
        }
    }
}
