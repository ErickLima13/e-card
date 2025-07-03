using UnityEngine;

public class PlayCardState : OpponentState
{
    [SerializeField] private Transform fieldPos;
    [SerializeField] private Sprite backCard;

    private TypeCard _mcardType;

    private BaseCard _mCard;

    public override void Do()
    {
        base.Do();
    }

    public override void Enter()
    {
        base.Enter();

        _mcardType = opponentIA.chooseCardState.ChooseCardToPlay();
        _mCard = opponentIA.chooseCardState.GetBaseCard();

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
        opponentIA.chooseCardState.SetCardInField(fieldPos);
        opponentIA.chooseCardState.RemoveCardOfList(_mcardType);
        turnControl.PlayCard(PlayerType.AI, _mcardType,_mCard);
        opponentIA.ChangeState(opponentIA.waitState);
    }
}
