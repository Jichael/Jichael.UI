using System.Collections.Generic;
using CustomPackages.Silicom.Localization.Runtime;
using Jichaels.StateMachine;
using TMPro;
using UnityEngine;

public class UIGuideQuestion : MonoBehaviour
{
    [SerializeField] private RectTransform answersContainer;
    [SerializeField] private UIGuideAnswerTemplate answerTemplate;
    [SerializeField] private TMP_Text questionTitle;
    [SerializeField] private TMP_Text questionText;
    
    private readonly List<UIGuideAnswerTemplate> _answers = new List<UIGuideAnswerTemplate>();

    public UIGuideQuestion CreateUI(GuideQuestion question, State state)
    {
        questionTitle.text = LanguageManager.Instance.RequestValue(question.titleKey);
        questionText.text = LanguageManager.Instance.RequestValue(question.questionKey);
        for (int i = 0; i < question.answers.Length; i++)
        {
            UIGuideAnswerTemplate answer = Instantiate(answerTemplate, answersContainer);
            answer.CreateUI(question.answers[i]);
            state.transitions[i].GetComponent<TCClickedUI>().clickableUI = answer.clickableUI;
            _answers.Add(answer);
        }
        return this;
    }
    
    public void SetDone()
    {
        for (int i = 0; i < _answers.Count; i++)
        {
            _answers[i].SetDone();
        }
        _answers.Clear();
        gameObject.SetActive(false);
    }

    public void SetToDo()
    {
        gameObject.SetActive(true);
    }
}