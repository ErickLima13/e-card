using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ChoosingTheFirstPlayerState : StateMachineBase
{
    [Inject]
    private readonly TurnControl turnControl;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();
        ChooseFirstPlayer();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void ChooseFirstPlayer()
    {
        int rand = Random.Range(0, 100);

        if (rand % 2 == 0)
        {
            turnControl.CreateTurn(PlayerType.Player);
        }
        else
        {
            turnControl.CreateTurn(PlayerType.AI);  
        }

        Manager.ChangeState(Manager.GetState<InGameState>());
    }
}
