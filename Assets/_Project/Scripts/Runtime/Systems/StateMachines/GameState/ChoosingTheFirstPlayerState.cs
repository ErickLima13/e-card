using UnityEngine;

public class ChoosingTheFirstPlayerState : StateMachineBase
{
    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        Manager.ChangeState(Manager.GetState<InGameState>());
    }

    public override void Exit()
    {
        base.Exit();
    }
}
