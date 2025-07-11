using System;
using UnityEngine;

public class DealTheCardsSubState : StateMachineBase
{
    public event Action OnFirstPlayerChooseEvent;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        OnFirstPlayerChooseEvent?.Invoke();
        Manager.ChangeState(Manager.GetState<EmperorTurnSubState>());
    }

    public override void Exit()
    {
        base.Exit();
    }
}
