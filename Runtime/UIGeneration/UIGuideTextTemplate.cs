using CustomPackages.Silicom.Localization.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGuideTextTemplate : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image icon;
    
    [SerializeField] private Sprite iconDone;
    [SerializeField] private Sprite iconToDo;

    [SerializeField] private Color colorDone;
    [SerializeField] private Color colorToDo;
    
    [SerializeField] private AudioClip toDoAudio;
    [SerializeField] private AudioClip doneAudio;
    
    public UIGuideTextTemplate CreateUI(GuideText guideText)
    {
        text.text = LanguageManager.Instance.RequestValue(guideText.textKey);
        return this;
    }

    public void SetDone()
    {
        icon.sprite = iconDone;
        icon.color = colorDone;
        text.color = colorDone;
        AudioManager.Instance.PlayUIClip(doneAudio);
    }

    public void SetToDo()
    {
        icon.sprite = iconToDo;
        icon.color = colorToDo;
        text.color = colorToDo;
        AudioManager.Instance.PlayUIClip(toDoAudio);
    }
}