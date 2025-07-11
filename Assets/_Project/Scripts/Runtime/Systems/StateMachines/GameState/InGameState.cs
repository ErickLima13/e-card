using UnityEngine;
using Zenject;

public class InGameState : StateMachineBase
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

        Manager.ChangeState(Manager.GetState<InitializingSubState>());
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void CheckCurrentPlayer()
    {
        switch (turnControl._currentTurn.FirstPlayer == PlayerType.Player) // trocar devido regra de 3 rodadas.
        {
            case true:
               
                break;
            case false:
        
                break;
        }
    }

}
