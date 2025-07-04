public class EmperorCardBehavior : CardBehaviorBase
{
    public override TypeCard Type => TypeCard.Emperor;

    protected override BattleResultType CalculateBattleCards(TypeCard card)
    {
        switch (card)
        {
            case TypeCard.Citizen:
                return BattleResultType.Win;
            case TypeCard.Slave:
                return BattleResultType.Defeat;
        }

        throw new System.NotImplementedException();
    }
}
