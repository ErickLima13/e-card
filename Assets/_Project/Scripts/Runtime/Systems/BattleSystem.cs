using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{

    public List<TypeCard> CardsOne = new();
    public List<TypeCard> CardsTwo = new();

    public TypeCard playerCard;

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
        hasCardPlayer = true;
    }

    [ContextMenu("Sort")]
    private void Sort()
    {
        CheckCards(ChooseCardToPlay(CardsOne, "primeira"), ChooseCardToPlay(CardsTwo, "segunda"));
    }

    private void CheckCards(TypeCard cOne, TypeCard cTwo)
    {
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

    private TypeCard ChooseCardToPlay(List<TypeCard> cards, string message)
    {
        int o = Random.Range(0, 100);
        TypeCard card = new();

        if (o >= 75 || cards.Count <= 1)
        {
            foreach (TypeCard c in cards)
            {
                if (c == TypeCard.Emperor || c == TypeCard.Slave)
                {
                    print($"{message} carta: {c}");
                    card = c;
                }
            }
        }
        else
        {
            foreach (TypeCard c in cards)
            {
                if (c == TypeCard.Citizen)
                {
                    print($"{message} carta: {c}");
                    card = c;
                    break;
                }
            }
        }


        if (card == TypeCard.Emperor)
        {
            isEmperor = true;
        }
        else if (card == TypeCard.Slave)
        {
            isSlave = true;
        }
        else
        {
            isCitizen = true;
        }

        cards.Remove(card);
        return card;
    }
}
