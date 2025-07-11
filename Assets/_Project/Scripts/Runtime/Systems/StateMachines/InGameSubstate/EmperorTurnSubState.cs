using UnityEngine;

public class EmperorTurnSubState : StateMachineBase
{
    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        SendFirtsPlayerPlay();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void SendFirtsPlayerPlay()
    {
        if (Manager.GetState<ChoosingTheFirstPlayerState>().IsAIFirstPlayer)
        {
            Manager.ChangeState(Manager.GetState<WaitState>());
        }
        else
        {
            Manager.ChangeState(Manager.GetState<SlaveTurnSubState>());
        }      
    }
}