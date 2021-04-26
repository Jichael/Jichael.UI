using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class UIAnimationController : MonoBehaviour
{
    [SerializeField] private UIAnimationEffect[] animationEffects;

    public RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    
    public Vector2 LayoutPosition { get; private set; }

    public bool AnimationPlaying => IsTranslating || IsRotating || IsScaling || IsFading;
    public bool IsTranslating { get; set; }
    public bool IsRotating { get; set; }
    public bool IsScaling { get; set; }
    public bool IsFading { get; set; }
    
    public void CacheLayoutPosition()
    {
        LayoutPosition = rectTransform.localPosition;
    }

    public void PlayAnimation(int i)
    {
        UIAnimationManager.Instance.PlayAnimation(this, animationEffects[i]);
    }

    private void OnValidate()
    {
        if (!rectTransform)
        {
            rectTransform = GetComponent<RectTransform>();
        }

        if (!canvasGroup)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }
    
#if UNITY_EDITOR

    [Header("Editor")]
    [SerializeField] private int indexLoadPreview;
    
    [Button]
    private void PreviewAnimation()
    {
        FindObjectOfType<UIAnimationManager>().PlayAnimation(this, animationEffects[indexLoadPreview]);
    }

    [SerializeField, InlineButton(nameof(LoadPreset), "Load")] private UIAnimationEffectPreset preset;
    private void LoadPreset()
    {
        if (!preset) return;
        
        animationEffects[indexLoadPreview].useUnscaledTime = preset.animationEffect.useUnscaledTime;
        animationEffects[indexLoadPreview].enableBefore = preset.animationEffect.enableBefore;
        animationEffects[indexLoadPreview].disableAfter = preset.animationEffect.disableAfter;
        
        animationEffects[indexLoadPreview].setPosition = preset.animationEffect.setPosition;
        animationEffects[indexLoadPreview].position = preset.animationEffect.position;
        
        animationEffects[indexLoadPreview].translation = preset.animationEffect.translation;
        animationEffects[indexLoadPreview].translationCurve = preset.animationEffect.translationCurve;
        animationEffects[indexLoadPreview].translationDuration = preset.animationEffect.translationDuration;
        animationEffects[indexLoadPreview].translationOffset = preset.animationEffect.translationOffset;
        animationEffects[indexLoadPreview].layoutControlled = preset.animationEffect.layoutControlled;
        
        animationEffects[indexLoadPreview].rotation = preset.animationEffect.rotation;
        animationEffects[indexLoadPreview].rotationCurve = preset.animationEffect.rotationCurve;
        animationEffects[indexLoadPreview].rotationDuration = preset.animationEffect.rotationDuration;
        animationEffects[indexLoadPreview].rotationMaxAngle = preset.animationEffect.rotationMaxAngle;
        
        animationEffects[indexLoadPreview].scaling = preset.animationEffect.scaling;
        animationEffects[indexLoadPreview].scalingCurve = preset.animationEffect.scalingCurve;
        animationEffects[indexLoadPreview].scalingDuration = preset.animationEffect.scalingDuration;
        animationEffects[indexLoadPreview].scalingMultiplier = preset.animationEffect.scalingMultiplier;
        
        animationEffects[indexLoadPreview].fade = preset.animationEffect.fade;
        animationEffects[indexLoadPreview].fadeCurve = preset.animationEffect.fadeCurve;
        animationEffects[indexLoadPreview].fadeDuration = preset.animationEffect.fadeDuration;

        EditorUtility.SetDirty(this);
    }
#endif
    
}
