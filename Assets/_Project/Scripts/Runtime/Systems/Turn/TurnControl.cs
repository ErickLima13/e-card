using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


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

[Serializable]
public struct CardsInField
{
    public BaseCard PlayerCard;
    public BaseCard AICard;

    public CardsInField(BaseCard player, BaseCard AI)
    {
        PlayerCard = player;
        AICard = AI;
    }
}


// jogar uma carta é um turno
// após os dois jogadores jogarem seu turno resulta um round.
// partida é um jogo completo composto por uma vitoria ou 3 empates.

/* O jogo é dividido em 12 partidas, e cada jogador permanece com o mesmo deck por 3 partidas,
* ou seja: se você começar com o Imperador, irá usalo por 3 partidas, depois passará pro seu 
* oponente e usará o deck do escravo. Depois de 3 partidas, o seu oponente irá fazer o mesmo, 
* e te passará o deck do Imperador, e assim vai, até alguém fazer 7 pontos ou o jogo acabar 
* empatado, com cada jogador possuindo 6 pontos. Não há desempate. */

// criar uma maquina de estado para cada tipo de deck para IA


public class TurnControl : MonoBehaviour
{
    public BattleState currentBattleState;

    public Turn _currentTurn;

    public PlayerType currentPlayer;

    public List<Turn> turns = new();
    [SerializeField] private List<BattleResult> _rounds = new();
    [SerializeField] private CardsInField _cardsInFields;

    private BaseCard player;
    private BaseCard AI;

    public void CreateTurn(PlayerType firstPlayer)
    {
        _currentTurn = new Turn(firstPlayer);
        currentPlayer = firstPlayer;
        ChangeBattleState(BattleState.FirstPlayer);
        print(firstPlayer);
    }

    public void PlayCard(PlayerType playerType, TypeCard typeCard, BaseCard baseCard)
    {
        if (playerType != _currentTurn.CurrentPlayerTurn)
        {
            print("Jogador errado");
            return;
        }

        _currentTurn.PlayCard(typeCard);

        switch (playerType)
        {
            case PlayerType.Player:
                player = baseCard;
                break;
            case PlayerType.AI:
                AI = baseCard;
                break;
        }

        if (_currentTurn.AllPlayersPlayed)
        {
            _cardsInFields = new(player, AI);
            ChangeBattleState(BattleState.Result);
            _ = DelayAnimation();
            return;
        }

        ChangeBattleState(BattleState.SecondPlayer);
    }

    private async Task DelayAnimation()
    {
        await UniTask.WaitForSeconds(1f);
        _cardsInFields.PlayerCard.RevealCard();
        _cardsInFields.AICard.RevealCard();

        await UniTask.WaitForSeconds(3f);

        _cardsInFields.PlayerCard.RemoveCardTheGame(-7);
        _cardsInFields.AICard.RemoveCardTheGame(7);

        await UniTask.WaitForSeconds(0.5f);
        ControlFinishTurn();
    }

    public void ControlFinishTurn()
    {
        _currentTurn.FinishTurn();

        Turn _lastTurn = _currentTurn;

        turns.Add(_lastTurn);

        var currentResult = _lastTurn.BattleResult.GetResultPlayer(PlayerType.Player);

        if (currentResult == BattleResultType.Win)
        {
            print("ganhei otaria");
        }

        //metodo de empate

        if (currentResult == BattleResultType.Tie)
        {
            CreateTurn(currentPlayer);
            ChangeBattleState(BattleState.FirstPlayer);
        }

        _rounds.Add(_lastTurn.BattleResult);
    }

    private void ChangeBattleState(BattleState state)
    {
        if (currentBattleState != state)
        {
            currentBattleState = state;
        }
    }
}
