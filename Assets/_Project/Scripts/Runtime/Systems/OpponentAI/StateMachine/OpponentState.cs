using UnityEngine;
using Zenject;

public class OpponentState : StateMachineBase
{
    [Inject]
    protected TurnControl turnControl;
    [Inject]
    protected CardSpawner cardSpawner;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}

