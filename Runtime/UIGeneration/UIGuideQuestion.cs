using System.Collections.Generic;
using CustomPackages.Silicom.Localization.Runtime;
using CustomPackages.Silicom.Player.CursorSystem;
using CustomPackages.Silicom.Player.Players;
using Silicom.StateMachine;
using TMPro;
using UnityEngine;

public class UIGuideQuestion : MonoBehaviour
{
    [SerializeField] private RectTransform answersContainer;
    [SerializeField] private UIGuideAnswerTemplate answerTemplate;
    [SerializeField] private TMP_Text questionTitle;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private AudioClip toDoAudio;
    
    
    private readonly List<UIGuideAnswerTemplate> _answers = new List<UIGuideAnswerTemplate>();

    public UIGuideQuestion CreateUI(GuideQuestion question, State state)
    {
        questionTitle.text = LanguageManager.Instance.RequestValue(question.titleKey);
        questionText.text = LanguageManager.Instance.RequestValue(question.questionKey);
        for (int i = 0; i < question.answers.Length; i++)
        {
            UIGuideAnswerTemplate answer = Instantiate(answerTemplate, answersContainer);
            answer.CreateUI(question.answers[i]);
            _answers.Add(answer);
        }

        return this;
    }

    public bool CheckAnswer(int answerIndex)
    {
        bool clicked = _answers[answerIndex].clickableUI.clicked;
        _answers[answerIndex].clickableUI.clicked = false;
        return clicked;
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
        AudioManager.Instance.PlayUIClip(toDoAudio);
    }
}