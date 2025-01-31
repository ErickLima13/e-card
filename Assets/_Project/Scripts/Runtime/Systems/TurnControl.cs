using System.Collections.Generic;
using UnityEngine;

public enum GameState
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
    public GameState currentState;
    [SerializeField] public Turn currentTurn;

    [SerializeField] public List<Turn> turns = new();

    public void CreateTurn(PlayerType firstPlayer)
    {
        currentTurn = new Turn(firstPlayer);
        ChangeState(GameState.FirstPlayer);
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
            ChangeState(GameState.Result);
            var firstPlayer = currentTurn.FirstPlayer;
            currentTurn.FinishTurn();
            print(currentTurn.BattleResult);

            // TODO: Isso deve ser usado depois da animação de revelar as cartas

            FinishTurn();
           

            // TODO: tirar isso e colocar na logica correta
            CreateTurn(firstPlayer);

            return;
        }

        ChangeState(GameState.SecondPlayer);
    }

    public void FinishTurn()
    {
        turns.Add(currentTurn);
        currentTurn = null;
    }

    private void ChangeState(GameState state)
    {
        if (currentState != state)
        {
            currentState = state;
        }
    }
}
