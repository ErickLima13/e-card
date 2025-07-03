using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    Animations,
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

 /* O jogo é dividido em 12 rounds, e cada jogador permanece com o mesmo deck por 3 rounds,
 * ou seja: se você começar com o Imperador, irá usalo por 3 turnos, depois passará pro seu 
 * oponente e usará o deck do escravo. Depois de 3 turnos, o seu oponente irá fazer o mesmo, 
 * e te passará o deck do Imperador, e assim vai, até alguém fazer 7 pontos ou o jogo acabar 
 * empatado, com cada jogador possuindo 6 pontos. Não há desempate. */


public class TurnControl : MonoBehaviour
{
    public BattleState currentBattleState;

    public Turn currentTurn;
    public PlayerType currentPlayer;

    public List<Turn> turns = new();
    [SerializeField] private List<Round> rounds = new();
    [SerializeField] private CardsInField _cardsInFields;

    private BaseCard player;
    private BaseCard AI;

    public void CreateTurn(PlayerType firstPlayer)
    {
        currentTurn = new Turn(firstPlayer);
        currentPlayer = firstPlayer;
        ChangeBattleState(BattleState.FirstPlayer);
        print(firstPlayer);
    }

    public void PlayCard(PlayerType playerType, TypeCard typeCard, BaseCard baseCard)
    {
        if (playerType != currentTurn.CurrentPlayerTurn)
        {
            print("Jogador errado");
            return;
        }

        currentTurn.PlayCard(typeCard);

        switch (playerType)
        {
            case PlayerType.Player:
                player = baseCard;
                break;
            case PlayerType.AI:
                AI = baseCard;
                break;
        }

        if (currentTurn.AllPlayersPlayed)
        {
            _cardsInFields = new(player, AI);

            //ChangeBattleState(BattleState.Result);

            ChangeBattleState(BattleState.Animations);

            DelayAnimation();


            currentTurn.FinishTurn();

            print(currentTurn.BattleResult);

            // TODO: Isso deve ser usado depois da animação de revelar as cartas

           

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

        await UniTask.WaitForSeconds(1f);
        FinishTurn();

    }

    public void FinishTurn()
    {
        BattleResult currentResult = currentTurn.BattleResult;
        turns.Add(currentTurn);
        currentTurn = null;

        if (currentResult == BattleResult.Win)
        {

        }

        //metodo de empate

        if (currentResult == BattleResult.Tie)
        {


            CreateTurn(currentPlayer);
            ChangeBattleState(BattleState.FirstPlayer);
        }
    }

    private void ChangeBattleState(BattleState state)
    {
        if (currentBattleState != state)
        {
            currentBattleState = state;
        }
    }
}
