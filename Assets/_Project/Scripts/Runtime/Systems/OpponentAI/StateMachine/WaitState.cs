using Cysharp.Threading.Tasks;

public class WaitState : OpponentState
{
    public bool isFirstPlayer;

    public override void Enter()
    {
        base.Enter();

        CheckFirstPlayer();
    }

    public override void Do()
    {
        base.Do();
    }

    private async void CheckFirstPlayer()
    {
        await UniTask.WaitUntil(() => turnControl.currentTurn != null);

        isFirstPlayer = turnControl.currentTurn.CurrentPlayerTurn == PlayerType.AI;

        if (!isFirstPlayer)
        {
            await UniTask.WaitUntil(() => turnControl.currentBattleState == BattleState.SecondPlayer);
        }

        if (turnControl.currentBattleState == BattleState.Battle)
        {
            print("aguardando resutado");
            return;
        }

        opponentIA.ChangeState(opponentIA.chooseCardState);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }
}
