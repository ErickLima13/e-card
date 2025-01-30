using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public TypeCard playerCard;
    public TypeCard AICard;

    private bool isEmperor;
    private bool isCitizen;
    private bool isSlave;

    public PlayerField playerField;

    private bool hasCardPlayer;
    private bool hasCardAI;

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
        CheckTypeOfCard(card);
        hasCardPlayer = true;
        Battle(playerCard, AICard);
    }

    public void TakeOpponentCard(TypeCard card)
    {
        AICard = card;
        CheckTypeOfCard(card);
        hasCardAI = true;
        Battle(playerCard, AICard);
    }

    private void CheckTypeOfCard(TypeCard card)
    {
        switch (card)
        {
            case TypeCard.Citizen:
                isCitizen = true;
                break;
            case TypeCard.Slave:
                isSlave = true;
                break;
            case TypeCard.Emperor:
                isEmperor = true;
                break;
        }
    }

    private void Battle(TypeCard cOne, TypeCard cTwo)
    {
        if (!hasCardPlayer || !hasCardAI)
        {
            return;
        }

        if (cOne == cTwo)
        {
            print("empate");
        }
        else
        {
            if (isEmperor && isCitizen)
            {
                print("imperador ganha");
            }
            else if (isCitizen && isSlave)
            {
                print("cidadao ganha");
            }
            else if (isEmperor && isSlave)
            {
                print("escravo ganha");
            }
        }

        isCitizen = false;
        isEmperor = false;
        isSlave = false;
    }
}
