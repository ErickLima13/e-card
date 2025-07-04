using System;

[Serializable]
public class Turn
{
    public TypeCard? FirstPlayerCard
    {
        get; private set;
    }
    public TypeCard? SecondPlayerCard
    {
        get; private set;
    }

    public PlayerType FirstPlayer
    {
        get; private set;
    }
    public PlayerType SecondPlayer
    {
        get; private set;
    }

    
    public BattleResult BattleResult
    {
        get; private set;
    }

    public PlayerType? CurrentPlayerTurn
    {
        get
        {
            if (IsFirstPlayerTurn)
            {
                return FirstPlayer;
            }

            if (IsSecondPlayerTurn)
            {
                return SecondPlayer;
            }

            return null;          
        }
    }

    public bool AllPlayersPlayed => FirstPlayerCard.HasValue && SecondPlayerCard.HasValue;
    public bool IsFirstPlayerTurn => !FirstPlayerCard.HasValue; 
    public bool IsSecondPlayerTurn => !SecondPlayerCard.HasValue;

    public Turn(PlayerType firstPlayer)
    {
        FirstPlayer = firstPlayer;
        SecondPlayer = firstPlayer == PlayerType.AI ? PlayerType.Player : PlayerType.AI;
    }

    public void PlayCard(TypeCard typeCard)
    {
        if (IsFirstPlayerTurn)
        {
            FirstPlayerCard = typeCard;
            UnityEngine.Debug.Log("primeiro jogador jogou");
            return;
        }

        if (IsSecondPlayerTurn)
        {
            SecondPlayerCard = typeCard;
            UnityEngine.Debug.Log("segundo jogador jogou");
            return;
        }

        UnityEngine.Debug.Log("jogada fora do turno");
    }

    public void FinishTurn()
    {
        var cardBehavior = BattleSystemFactory.Create(FirstPlayerCard.Value);
        BattleResult = cardBehavior.BattleCards(SecondPlayerCard.Value, FirstPlayer);
    }
}