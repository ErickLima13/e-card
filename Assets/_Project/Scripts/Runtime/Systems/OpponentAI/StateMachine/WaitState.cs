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
        await UniTask.WaitUntil(() => turnControl._currentTurn != null);

        if (gameManager.IsAIFirstPlayer && turnControl.currentBattleState != BattleState.FirstPlayer)
        {
            print("AI : já joguei");
            await UniTask.WaitUntil(() => turnControl.currentBattleState == BattleState.FirstPlayer);
        }

        if (!gameManager.IsAIFirstPlayer)
        {
            await UniTask.WaitUntil(() => turnControl.currentBattleState == BattleState.SecondPlayer);
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
