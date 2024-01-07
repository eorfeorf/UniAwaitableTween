using System;
using System.Threading;
using UniAwaitableTween.Runtime;
using UnityEngine;

public class Sample : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private CancellationTokenSource _cts;

    private async void Start()
    {
        await Tween.Move(_target, Vector3.up, 0.1f);
        await Tween.Move(_target, Vector3.down, 0.1f);
        await _target.Move(Vector3.left, 0.1f);
        await _target.Move(Vector3.right, 0.1f);
        await Tween.ColorFade(_target.gameObject.GetComponent<MeshRenderer>().material, Color.black, 1f);
        await Tween.ColorFade(_target.gameObject.GetComponent<MeshRenderer>().material, Color.white, 1f);
    }

    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();
            await Tween.Move(_target, Vector3.up, 0.1f, _cts.Token);
            await Tween.Move(_target, Vector3.down, 0.1f, _cts.Token);
        }
    }

    private void OnDestroy()
    {
        _cts?.Cancel();
        _cts?.Dispose();
    }
}
