public interface ICardBehavior
{
    TypeCard Type
    {
        get;
    }

    BattleResult BattleAgainst(TypeCard card);
}

public enum BattleResult
{
    Tie,
    Win,
    Defeat
}