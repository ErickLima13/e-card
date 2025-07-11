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

        _mcardType = Manager.GetState<ChooseCardState>().ChooseCardToPlay();
        _mCard = Manager.GetState<ChooseCardState>().GetBaseCard();

        PlayCardAI();
    }

    public override void Exit()
    {
       
        base.Exit();
    }

    private void PlayCardAI()
    {
        Manager.GetState<ChooseCardState>().SetCardInField(fieldPos);
        Manager.GetState<ChooseCardState>().RemoveCardOfList(_mcardType);
        turnControl.PlayCard(PlayerType.AI, _mcardType,_mCard);
    }
}
