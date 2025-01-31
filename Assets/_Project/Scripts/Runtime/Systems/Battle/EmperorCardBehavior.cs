public class EmperorCardBehavior : ICardBehavior
{
    public TypeCard Type => TypeCard.Emperor;

    public BattleResult BattleAgainst(TypeCard card)
    {
        switch (card)
        {
            case TypeCard.Citizen:
                return BattleResult.Win;
            case TypeCard.Slave:
                return BattleResult.Defeat;
        }

        throw new System.NotImplementedException();
    }
}
