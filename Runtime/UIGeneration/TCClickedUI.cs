using Jichaels.StateMachine;

public class TCClickedUI : TransitionCondition
{
    public ClickableUI clickableUI;

    public override bool Condition => clickableUI.clicked;
    public override void Reset() {}
}