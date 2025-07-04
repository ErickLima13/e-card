using System;

public abstract class CardBehaviorBase
{
    public abstract TypeCard Type
    {
        get;
    }

    protected abstract BattleResultType CalculateBattleCards(TypeCard card);

    public BattleResult BattleCards(TypeCard card, PlayerType player)
    {
        return new BattleResult(
            CalculateBattleCards(card),
            player
        );
    }
}

public enum BattleResultType
{
    Defeat = -1,
    Tie = 0,
    Win = 1
}


[Serializable]
public class BattleResult
{
    public BattleResultType _resultType;
    public PlayerType _playerType;

    public BattleResult(BattleResultType resultType, PlayerType player)
    {
        _resultType = resultType;
        _playerType = player;
    }

    public BattleResultType GetResultPlayer(PlayerType player)
    {
        if (player == _playerType)
        {
            return _resultType;
        }

        int value = ((int)_resultType * -1);
        return (BattleResultType)value;

    }

}