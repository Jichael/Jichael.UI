using Silicom.StateMachine;
using UnityEngine;

public class UIGeneration : MonoBehaviour
{
    public static UIGeneration Instance { get; private set; }
    
    public UIGuideQuestion uiGuideQuestion;
    
    [SerializeField] private UIGuideTextTemplate guideTextTemplate;
    [SerializeField] private Transform actionListContainer;

    private void Awake()
    {
        Instance = this;
    }

    public UIGuideTextTemplate CreateUI(GuideText state)
    {
        UIGuideTextTemplate guideText = Instantiate(guideTextTemplate, actionListContainer);
        guideText.CreateUI(state).SetToDo();
        return guideText;
    }

    public void CreateUI(GuideQuestion question, State state)
    {
        uiGuideQuestion.CreateUI(question, state).SetToDo();
    }

}
