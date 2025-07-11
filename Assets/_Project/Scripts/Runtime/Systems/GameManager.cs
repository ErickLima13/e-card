using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public event Action OnFirstPlayerChooseEvent;

    public bool IsAIFirstPlayer
    {
        get; private set;
    }

    public GameManagerType CurrentGameState
    {
        get; private set;
    }

    [Inject]
    private readonly TurnControl turnControl;

    private void Start()
    {
        ChangeGameState(GameManagerType.ChooseFirstPlayer);
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
            IsAIFirstPlayer = true;
        }

        ChangeGameState(GameManagerType.ArrangeCards);
        OnFirstPlayerChooseEvent?.Invoke();
    }

    private void ChangeGameState(GameManagerType newState)
    {
        if (CurrentGameState != newState)
        {
            CurrentGameState = newState;
        }
    }
}
