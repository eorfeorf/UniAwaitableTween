﻿using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    public abstract class SequenceBase<LerpType> : ISequence
    {
        private SequenceData<LerpType> _data;

        /// <summary>
        /// 補間データの初期化.
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        protected void Initialize(LerpType begin, LerpType end, float startTime, float endTime)
        {
            _data = new SequenceData<LerpType>(begin, end, startTime, endTime);
        }

        /// <summary>
        /// 時間経過による補間.
        /// </summary>
        /// <param name="ct"></param>
        public async UniTask UpdateAsync(CancellationToken ct)
        {
            while (true)
            {
                ct.ThrowIfCancellationRequested();

                var t = (Time.time - _data.StartTime) / (_data.EndTime - _data.StartTime);
                t = Mathf.Clamp01(t);
                if (t > 1f)
                {
                    return;
                }
                UpdateLerp(_data.Start, _data.End, t);
                await UniTask.Yield();
            }
        }
        
        /// <summary>
        /// 補間関数.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected abstract void UpdateLerp(LerpType start, LerpType end, float t);
    }
}