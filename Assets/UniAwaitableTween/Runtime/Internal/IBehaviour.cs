﻿using System.Threading;
using Cysharp.Threading.Tasks;

namespace UniAwaitableTween.Runtime
{
    /// <summary>
    /// シーケンスを実現させるための最低限の機能.
    /// </summary>
    public interface IBehaviour
    {
        public UniTask UpdateAsync(CancellationToken ct);
        public void SetLerpT(float t);
    }
}