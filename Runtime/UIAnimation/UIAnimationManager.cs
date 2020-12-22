using System.Collections;
using CustomPackages.Silicom.Core.Runtime;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    
    public static UIAnimationManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
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
        
        if (animationEffect.translation)
        {
            // TODO : should we do this here or only when needed ?
            controller.CacheLayoutPosition();
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
    }
  
    private static IEnumerator TranslationCo(UIAnimationController controller, UIAnimationEffect animationEffect)
    {
        controller.IsTranslating = true;

        Vector2 startPos = controller.LayoutPosition + animationEffect.translationOffset;
        Vector2 endPos = controller.LayoutPosition;

        float delta = 0;

        while (delta < 1)
        {
            delta += Time.deltaTime / animationEffect.translationDuration;
            controller.rectTransform.localPosition = Vector3.Lerp(startPos, endPos, animationEffect.translationCurve.Evaluate(delta));
            yield return Yielders.EndOfFrame;
        }
        
        controller.IsTranslating = false;
    }
    
    private static IEnumerator RotationCo(UIAnimationController controller, UIAnimationEffect animationEffect)
    {
        controller.IsRotating = true;
        
        Vector3 rotation = controller.rectTransform.localEulerAngles;
        
        float delta = 0;

        while (delta < 1)
        {
            delta += Time.deltaTime / animationEffect.rotationDuration;
            rotation.z = animationEffect.rotationCurve.Evaluate(delta) * animationEffect.rotationMaxAngle;
            controller.rectTransform.localEulerAngles = rotation;
            yield return Yielders.EndOfFrame;
        }

        controller.IsRotating = false;
    }
    
    private static IEnumerator ScalingCo(UIAnimationController controller, UIAnimationEffect animationEffect)
    {
        controller.IsScaling = true;

        Vector3 scale = controller.rectTransform.localScale;
        
        float delta = 0;

        while (delta < 1)
        {
            delta += Time.deltaTime / animationEffect.scalingDuration;
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
        controller.IsFading = true;
        
        float delta = 0;

        while (delta < 1)
        {
            delta += Time.deltaTime / animationEffect.fadeDuration;
            float tmp = animationEffect.fadeCurve.Evaluate(delta);
            controller.canvasGroup.alpha = tmp;
            yield return Yielders.EndOfFrame;
        }
        
        controller.IsFading = false;
    }
}
