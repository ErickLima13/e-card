public class CitizenCardBehavior : CardBehaviorBase
{
    public override TypeCard Type => TypeCard.Citizen;

    protected override BattleResultType CalculateBattleCards(TypeCard card)
    {
        switch (card)
        {
            case TypeCard.Citizen:
                return BattleResultType.Tie;
            case TypeCard.Slave:
                return BattleResultType.Win;
            case TypeCard.Emperor:
                return BattleResultType.Defeat;
        }     
        
        throw new System.NotImplementedException();
    }

   
}
