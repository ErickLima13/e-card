public class CitizenCardBehavior : ICardBehavior
{
    public TypeCard Type => TypeCard.Citizen;

    public BattleResult BattleAgainst(TypeCard card)
    {
        switch (card)
        {
            case TypeCard.Citizen:
                return BattleResult.Tie;
            case TypeCard.Slave:
                return BattleResult.Win;
            case TypeCard.Emperor:
                return BattleResult.Defeat;
        }     
        
        throw new System.NotImplementedException();
    }
}
