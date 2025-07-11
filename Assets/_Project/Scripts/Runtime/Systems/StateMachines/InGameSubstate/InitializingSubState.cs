using UnityEngine;

public class InitializingSubState : StateMachineBase
{
    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        Manager.ChangeState(Manager.GetState<DealTheCardsSubState>());
    }

    public override void Exit()
    {
        base.Exit();
    }
}
