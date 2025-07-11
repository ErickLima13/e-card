using Cysharp.Threading.Tasks;

public class WaitState : OpponentState
{
    public bool AlreadyPlayed;

    
    public override void Enter()
    {
        base.Enter();
        AlreadyPlayed = false;
        CheckFirstPlayer();
    }

    public override void Do()
    {
        base.Do();
    }

    private void CheckFirstPlayer()
    {
        //await UniTask.WaitUntil(() => turnControl._currentTurn != null);

        //if (Manager.GetState<ChoosingTheFirstPlayerState>().IsAIFirstPlayer && turnControl.currentBattleState != BattleState.FirstPlayer)
        //{
        //    print("AI : já joguei");
        //    await UniTask.WaitUntil(() => turnControl.currentBattleState == BattleState.FirstPlayer);
        //}

        //if (!gameManager.IsAIFirstPlayer)
        //{
        //    await UniTask.WaitUntil(() => turnControl.currentBattleState == BattleState.SecondPlayer);
        //}


        if (AlreadyPlayed)
        {
            return;
        }

        Manager.ChangeState(Manager.GetState<ChooseCardState>());
    }

    public override void Exit()
    {
        AlreadyPlayed = true;
        base.Exit();
    }

    private void OnEnable()
    {
       turnControl.OnCardPlayedEvent += CheckIsMyTime;
    }

    private void OnDisable()
    {
        turnControl.OnCardPlayedEvent -= CheckIsMyTime;
    }

    private void CheckIsMyTime(PlayerType player)
    {
        if(player == PlayerType.Player)
        {
            return;
        }
        else
        {
            Manager.ChangeState(Manager.GetState<ChooseCardState>());
        }

    }
}
