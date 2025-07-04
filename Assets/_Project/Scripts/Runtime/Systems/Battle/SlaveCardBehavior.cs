public class SlaveCardBehavior : CardBehaviorBase
{
    public override TypeCard Type => TypeCard.Slave;

    protected override BattleResultType CalculateBattleCards(TypeCard card)
    {
        switch (card)
        {
            case TypeCard.Citizen:
                return BattleResultType.Defeat;
            case TypeCard.Emperor:
                return BattleResultType.Win;
        }

        throw new System.NotImplementedException();
    }
}
