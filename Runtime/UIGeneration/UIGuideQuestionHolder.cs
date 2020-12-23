using Jichaels.StateMachine;
using UnityEngine;

public class UIGuideQuestionHolder : MonoBehaviour
{
    public GuideQuestion question;
    public State state;

    private void OnValidate()
    {
        state = GetComponent<State>();
    }

    public void CreateUI()
    {
        UIGeneration.Instance.CreateUI(question, state);
    }

    public void SetDone()
    {
        UIGeneration.Instance.uiGuideQuestion.SetDone();
    }
}