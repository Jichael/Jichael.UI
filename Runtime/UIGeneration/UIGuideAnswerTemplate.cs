using CustomPackages.Silicom.Localization.Runtime;
using TMPro;
using UnityEngine;

public class UIGuideAnswerTemplate : MonoBehaviour
{
    public TMP_Text text;
    public ClickableUI clickableUI;
    public GuideQuestion.Answer Answer { get; set; }
    
    public void CreateUI(GuideQuestion.Answer answer)
    {
        Answer = answer;
        text.text = LanguageManager.Instance.RequestValue(Answer.answerKey);
    }

    public void SetDone()
    {
        Destroy(gameObject);
    }

    public void SetToDo()
    {
        
    }
}