using UnityEngine;


public enum GameState
{
    PlayerTurn,
    OpponentTurn,
    Battle,
    Result

}

public class TurnControl : MonoBehaviour
{
    public GameState currentState;





    public void ChangeState(GameState state)
    {
        if (currentState != state)
        {
            currentState = state;
        }
    }
}
