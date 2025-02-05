using System.Collections.Generic;
using UnityEngine;

public class PlayCardState : OpponentState
{
    public Transform fieldPos;
    [SerializeField] private Sprite backCard;

    private TypeCard mcardType;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        mcardType = opponentIA.chooseCardState.ChooseCardToPlay();

        PlayCardAI();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    private void PlayCardAI()
    {
        turnControl.PlayCard(PlayerType.AI,mcardType);
        opponentIA.chooseCardState.SetCardInField(fieldPos);
        opponentIA.chooseCardState.RemoveCardOfList(mcardType);
       

        opponentIA.ChangeState(opponentIA.waitState);
    }
}
