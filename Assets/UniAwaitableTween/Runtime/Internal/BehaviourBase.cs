﻿using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    public abstract class BehaviourBase<TValue> : IBehaviour
    {
        private readonly BehaviourData<TValue> _data;

        /// <summary>
        /// 補間データの初期化.
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        protected BehaviourBase(TValue begin, TValue end, float startTime, float endTime)
        {
            _data = new BehaviourData<TValue>(begin, end, startTime, endTime);
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
                if (t > 1f)
                {
                    return;
                }
                t = Mathf.Clamp01(t);
                UpdateLerp(_data.Start, _data.End, t);
                await UniTask.Yield();
            }
        }

        /// <summary>
        /// Lerpのtを設定する.
        /// </summary>
        /// <param name="t"></param>
        public void SetLerpT(float t)
        {
            UpdateLerp(_data.Start, _data.End, t);
        }

        /// <summary>
        /// 補間関数.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected abstract void UpdateLerp(TValue start, TValue end, float t);
    }
}