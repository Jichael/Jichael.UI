using CustomPackages.Silicom.Localization.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGuideTextTemplate : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image icon;

    [SerializeField] private Color colorDone;
    [SerializeField] private Color colorToDo;
    
    [SerializeField] private AudioClip toDoAudio;
    [SerializeField] private AudioClip doneAudio;

    [SerializeField] private float toDoTextSize;
    [SerializeField] private float doneTextSize;
    

    [SerializeField] private UIAnimationController iconController;
    
    
    public UIGuideTextTemplate CreateUI(GuideText guideText)
    {
        text.text = LanguageManager.Instance.RequestValue(guideText.textKey);
        return this;
    }

    public void SetDone()
    {
        icon.color = colorDone;
        text.color = colorDone;
        text.fontSize = doneTextSize;
        iconController.PlayAnimation(1);
        AudioManager.Instance.PlayUIClip(doneAudio);
    }

    public void SetToDo()
    {
        icon.color = colorToDo;
        text.color = colorToDo;
        text.fontSize = toDoTextSize;
        AudioManager.Instance.PlayUIClip(toDoAudio);
    }
}