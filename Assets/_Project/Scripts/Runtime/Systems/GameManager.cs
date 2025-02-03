using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public event Action OnFirstPlayerChooseEvent;

    public GameState CurrentGameState
    {
        get; private set;
    }

    [Inject]
    private readonly TurnControl turnControl;

    private void Start()
    {
        ChangeGameState(GameState.ChooseFirstPlayer);
        ChooseFirstPlayer();
    }

    private void ChooseFirstPlayer()
    {
        int rand = Random.Range(0, 100);

        if (rand % 2 == 0)
        {
            turnControl.CreateTurn(PlayerType.Player);
        }
        else
        {
            turnControl.CreateTurn(PlayerType.AI);
        }

        ChangeGameState(GameState.ArrangeCards);
        OnFirstPlayerChooseEvent?.Invoke();
    }

    private void ChangeGameState(GameState newState)
    {
        if (CurrentGameState != newState)
        {
            CurrentGameState = newState;
        }
    }

}
