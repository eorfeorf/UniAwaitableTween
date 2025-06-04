using UnityEngine;

namespace UniAwaitableTween.Runtime
{
    public enum EasingType
    {
        Linear,
        EaseInOut,
        EaseOutQuad,
    }

    public static class Easing
    {
        public static float Evaluate(EasingType type, float t)
        {
            switch (type)
            {
                case EasingType.EaseInOut:
                    return EaseInOut(t);
                case EasingType.EaseOutQuad:
                    return EaseOutQuad(t);
                case EasingType.Linear:
                default:
                    return t;
            }
        }

        public static float EaseInOut(float t)
        {
            return t * t * (3f - 2f * t);
        }

        public static float EaseOutQuad(float t)
        {
            return t * (2f - t);
        }
    }
}
