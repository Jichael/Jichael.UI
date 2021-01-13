using Silicom.StateMachine;
using UnityEngine;

public class TCCheckAnswer : TransitionCondition
{
    [SerializeField] private UIGuideQuestion uiGuideQuestion;
    [SerializeField] private int answerIndex;

    public override bool Condition => uiGuideQuestion.CheckAnswer(answerIndex);
    public override void ResetCondition() {}
}