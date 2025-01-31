public class SlaveCardBehavior : ICardBehavior
{
    public TypeCard Type => TypeCard.Slave;

    public BattleResult BattleAgainst(TypeCard card)
    {
        switch (card)
        {
            case TypeCard.Citizen:
                return BattleResult.Defeat;
            case TypeCard.Emperor:
                return BattleResult.Win;
        }

        throw new System.NotImplementedException();
    }
}
