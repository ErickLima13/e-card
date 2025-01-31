using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BattleSystem : MonoBehaviour
{
    public TypeCard playerCard;
    public TypeCard AICard;

    public PlayerField playerField;

    private bool hasCardPlayer;
    private bool hasCardAI;

    public BattleResult battleResult;

    [Inject]
    public TurnControl turnControl;

    private void Start()
    {
        playerField = FindFirstObjectByType<PlayerField>();
        playerField.OnCardIsPlayedEvent += TakePlayerCard;
    }

    private void OnDisable()
    {
        playerField.OnCardIsPlayedEvent -= TakePlayerCard;
    }


    private void TakePlayerCard(TypeCard card)
    {
        playerCard = card;
        hasCardPlayer = true;
        Battle(playerCard, AICard);
    }

    public void TakeOpponentCard(TypeCard card)
    {
        AICard = card;
        hasCardAI = true;
        Battle(playerCard, AICard);
    }

    private void Battle(TypeCard cOne, TypeCard cTwo)
    {
        if (!hasCardPlayer || !hasCardAI)
        {
            return;
        }

        var cardBehavior = BattleSystemFactory.Create(cOne);
        battleResult =  cardBehavior.BattleAgainst(cTwo);
        //turnControl.ChangeState(GameState.Result);
    }
}
