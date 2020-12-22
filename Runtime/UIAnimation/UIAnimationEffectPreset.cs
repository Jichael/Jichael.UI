using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "UIAnimationEffect", menuName = "UI/AnimationEffect", order = 1)]
public class UIAnimationEffectPreset : ScriptableObject
{
    [HideLabel] public UIAnimationEffect animationEffect;
}