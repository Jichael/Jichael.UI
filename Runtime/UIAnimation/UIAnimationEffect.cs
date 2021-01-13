using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class UIAnimationEffect
{
    public bool NeedsRectTransform => translation || rotation || scaling;
    public bool NeedsCanvasGroup => fade;

    public bool useUnscaledTime;
    
    [BoxGroup("Translation")] public bool translation;
    [BoxGroup("Translation"), ShowIf(nameof(translation))] public AnimationCurve translationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [BoxGroup("Translation"), ShowIf(nameof(translation))] public float translationDuration;
    [BoxGroup("Translation"), ShowIf(nameof(translation))] public Vector2 translationOffset;
    
    [BoxGroup("Rotation")] public bool rotation;
    [BoxGroup("Rotation"), ShowIf(nameof(rotation))] public AnimationCurve rotationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [BoxGroup("Rotation"), ShowIf(nameof(rotation))] public float rotationDuration;
    [BoxGroup("Rotation"), ShowIf(nameof(rotation))] public float rotationMaxAngle = 360;
    
    [BoxGroup("Scaling")] public bool scaling;
    [BoxGroup("Scaling"), ShowIf(nameof(scaling))] public AnimationCurve scalingCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [BoxGroup("Scaling"), ShowIf(nameof(scaling))] public float scalingDuration;
    [BoxGroup("Scaling"), ShowIf(nameof(scaling))] public float scalingMultiplier = 1;
    
    [BoxGroup("Fade")] public bool fade;
    [BoxGroup("Fade"), ShowIf(nameof(fade))] public AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [BoxGroup("Fade"), ShowIf(nameof(fade))] public float fadeDuration;
}