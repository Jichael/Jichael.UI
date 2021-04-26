using System.Collections;
using CustomPackages.Silicom.Core.Runtime;
#if UNITY_EDITOR
using Unity.EditorCoroutines.Editor;
using UnityEditor;
#endif
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    
    public static UIAnimationManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayAnimation(UIAnimationController controller, UIAnimationEffect animationEffect)
    {
        if (controller.AnimationPlaying) return;

        if (animationEffect.NeedsRectTransform && !controller.rectTransform)
        {
            Debug.LogError($"{controller.name} needs a RectTransform but doesn't have one !");
            return;
        }
        
        if (animationEffect.NeedsCanvasGroup && !controller.canvasGroup)
        {
            Debug.LogError($"{controller.name} needs a CanvasGroup but doesn't have one !");
            return;
        }

        StartCoroutine(AnimationCo(controller, animationEffect));
    }

    private IEnumerator AnimationCo(UIAnimationController controller, UIAnimationEffect animationEffect)
    {
        if (animationEffect.setPosition)
        {
            controller.rectTransform.anchoredPosition = animationEffect.position;
        }
        
        if (animationEffect.enableBefore)
        {
            controller.gameObject.SetActive(true);
        }
        
        if (animationEffect.translation)
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                StartCoroutine(TranslationCo(controller, animationEffect));
            }
            else
            {
                EditorCoroutineUtility.StartCoroutine(TranslationCo(controller, animationEffect), controller);
            }
#else
            StartCoroutine(TranslationCo(controller, animationEffect));
#endif
        }

        if (animationEffect.rotation)
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                StartCoroutine(RotationCo(controller, animationEffect));
            }
            else
            {
                EditorCoroutineUtility.StartCoroutine(RotationCo(controller, animationEffect), controller);
            }
#else
            StartCoroutine(RotationCo(controller, animationEffect));
#endif
        }

        if (animationEffect.scaling)
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                StartCoroutine(ScalingCo(controller, animationEffect));
            }
            else
            {
                EditorCoroutineUtility.StartCoroutine(ScalingCo(controller, animationEffect), controller);
            }
#else
            StartCoroutine(ScalingCo(controller, animationEffect));
#endif
        }

        if (animationEffect.fade)
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                StartCoroutine(FadeCo(controller, animationEffect));
            }
            else
            {
                EditorCoroutineUtility.StartCoroutine(FadeCo(controller, animationEffect), controller);
            }
#else
            StartCoroutine(FadeCo(controller, animationEffect));
#endif
        }

        if (animationEffect.disableAfter)
        {
            while (controller.AnimationPlaying) yield return Yielders.EndOfFrame;
            controller.gameObject.SetActive(false);
        }
    }
  
    private static IEnumerator TranslationCo(UIAnimationController controller, UIAnimationEffect animationEffect)
    {
        while (controller.IsTranslating) yield return Yielders.EndOfFrame;
        controller.IsTranslating = true;

        Vector2 startPos;
        Vector2 endPos;
        if (animationEffect.layoutControlled)
        {
            controller.CacheLayoutPosition();
            startPos = controller.LayoutPosition + animationEffect.translationOffset;
            endPos = controller.LayoutPosition;
        }
        else
        {
            startPos = controller.rectTransform.localPosition;
            endPos = startPos + animationEffect.translationOffset;
        }

        float delta = 0;

        while (delta < 1)
        {
            delta += (animationEffect.useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime) / animationEffect.translationDuration;
            controller.rectTransform.localPosition = Vector3.Lerp(startPos, endPos, animationEffect.translationCurve.Evaluate(delta));
            yield return Yielders.EndOfFrame;
        }
        
        controller.IsTranslating = false;
    }
    
    private static IEnumerator RotationCo(UIAnimationController controller, UIAnimationEffect animationEffect)
    {
        while (controller.IsRotating) yield return Yielders.EndOfFrame;
        controller.IsRotating = true;
        
        Vector3 rotation = controller.rectTransform.localEulerAngles;
        
        float delta = 0;

        while (delta < 1)
        {
            delta += (animationEffect.useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime) / animationEffect.rotationDuration;
            rotation.z = animationEffect.rotationCurve.Evaluate(delta) * animationEffect.rotationMaxAngle;
            controller.rectTransform.localEulerAngles = rotation;
            yield return Yielders.EndOfFrame;
        }

        controller.IsRotating = false;
    }
    
    private static IEnumerator ScalingCo(UIAnimationController controller, UIAnimationEffect animationEffect)
    {
        while (controller.IsScaling) yield return Yielders.EndOfFrame;
        controller.IsScaling = true;

        Vector3 scale = controller.rectTransform.localScale;
        
        float delta = 0;

        while (delta < 1)
        {
            delta += (animationEffect.useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime) / animationEffect.scalingDuration;
            float tmp = animationEffect.scalingCurve.Evaluate(delta) * animationEffect.scalingMultiplier;
            scale.x = tmp;
            scale.y = tmp;
            controller.rectTransform.localScale = scale;
            yield return Yielders.EndOfFrame;
        }

        controller.IsScaling = false;
    }
    
    private static IEnumerator FadeCo(UIAnimationController controller, UIAnimationEffect animationEffect)
    {
        while (controller.IsFading) yield return Yielders.EndOfFrame;
        controller.IsFading = true;
        
        float delta = 0;

        while (delta < 1)
        {
            delta += (animationEffect.useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime) / animationEffect.fadeDuration;
            float tmp = animationEffect.fadeCurve.Evaluate(delta);
            controller.canvasGroup.alpha = tmp;
            yield return Yielders.EndOfFrame;
        }

        controller.IsFading = false;
    }
}