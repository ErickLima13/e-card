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
        await UniTask.WaitUntil(() => gameManager.CurrentGameState == GameState.ArrangeCards);

        if (turnControl.currentPlayer != PlayerType.AI)
        {
            print("AI : não sou eu que começo ou eu já joguei");
            return;
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
