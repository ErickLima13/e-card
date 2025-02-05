using System;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class Round
{
    public PlayerType PlayerType;
    public BattleResult battleResult;
}

public enum GameState
{
    ChooseFirstPlayer,
    ArrangeCards
}

public enum BattleState
{
    FirstPlayer,
    SecondPlayer,
    Battle,
    Result
}

public enum PlayerType
{
    Player = 1,
    AI = 2
}

public class TurnControl : MonoBehaviour
{
    public BattleState currentBattleState;
    public BattleResult battleResult;

    public Turn currentTurn;
    public PlayerType currentPlayer;

    public List<Turn> turns = new();
    [SerializeField] private List<Round> rounds = new();


    public void CreateTurn(PlayerType firstPlayer)
    {
        currentTurn = new Turn(firstPlayer);
        currentPlayer = firstPlayer;
        ChangeBattleState(BattleState.FirstPlayer);
        print(firstPlayer);
    }

    public void PlayCard(PlayerType playerType, TypeCard typeCard)
    {
        if (playerType != currentTurn.CurrentPlayerTurn)
        {
            print("Jogador errado");
            return;
        }

        currentTurn.PlayCard(typeCard);

        if (currentTurn.AllPlayersPlayed)
        {
            ChangeBattleState(BattleState.Result);
            var firstPlayer = currentTurn.FirstPlayer;
            currentTurn.FinishTurn();
            print(currentTurn.BattleResult);

            // TODO: Isso deve ser usado depois da animação de revelar as cartas

            FinishTurn();


            // TODO: tirar isso e colocar na logica correta
            //CreateTurn(firstPlayer);

            return;
        }

        ChangeBattleState(BattleState.SecondPlayer);
    }

    public void FinishTurn()
    {
        turns.Add(currentTurn);
        currentTurn = null;
    }

    private void ChangeBattleState(BattleState state)
    {
        if (currentBattleState != state)
        {
            currentBattleState = state;
        }
    }
}
