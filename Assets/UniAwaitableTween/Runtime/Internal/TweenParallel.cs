using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// Executes multiple <see cref="IBehaviour"/> instances concurrently.
    /// </summary>
    public sealed class TweenParallel : IBehaviour
    {
        private readonly IBehaviour[] _behaviours;

        public TweenParallel(IEnumerable<IBehaviour> behaviours)
        {
            _behaviours = behaviours is IBehaviour[] array ? array : new List<IBehaviour>(behaviours).ToArray();
        }

        public async UniTask UpdateAsync(CancellationToken ct)
        {
            var tasks = new List<UniTask>(_behaviours.Count);
            foreach (var behaviour in _behaviours)
            {
                tasks.Add(BehaviourController.PlayAsync(behaviour, ct));
            }
            await UniTask.WhenAll(tasks);
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
