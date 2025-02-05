using Cysharp.Threading.Tasks;

public class WaitState : OpponentState
{
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

        if (gameManager.IsAIFirstPlayer && turnControl.currentBattleState != BattleState.FirstPlayer)
        {
            print("AI : já joguei");
            await UniTask.WaitUntil(() => turnControl.currentBattleState == BattleState.FirstPlayer);
            
            //return;
        }

        if (!gameManager.IsAIFirstPlayer)
        {
            await UniTask.WaitUntil(() => turnControl.currentBattleState == BattleState.SecondPlayer);
        }

        if (turnControl.currentBattleState == BattleState.Result)
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
