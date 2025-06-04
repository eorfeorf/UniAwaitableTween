# UniAwaitableTween

A simple awaitable tweening system for Unity using UniTask.

## Installation

Add this repository to your Unity project via the Package Manager using the Git URL:

```
https://github.com/username/UniAwaitableTween.git?path=Assets/UniAwaitableTween
```

Alternatively, copy the `Assets/UniAwaitableTween` folder into your project.

## Usage

Import the namespace and call the tween methods. `Tween.Move` moves a transform by an offset relative to its current position. `Tween.ColorFade` fades a material's color.

```csharp
using UniAwaitableTween.Runtime;

await Tween.Move(transform, Vector3.up, 0.5f);
await Tween.ColorFade(renderer.material, Color.black, 1.0f);
```

You can also use the `Move` extension method on `Transform`.
