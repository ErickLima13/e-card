using System.Collections.Generic;
using UnityEngine;

public enum Card
{
    Citizen,
    Slave,
    Emperor
}

public class TypeCard : MonoBehaviour
{
    public List<Card> CardsOne = new();
    public List<Card> CardsTwo = new();

    public bool tie;
    public bool win;
    public bool defeat;

    private bool isEmperor;
    private bool isCitizen;
    private bool isSlave;

    private void Start()
    {
        Sort();
    }

    [ContextMenu("Sort")]
    private void Sort()
    {
        CheckCards(ChooseCardToPlay(CardsOne, "primeira"), ChooseCardToPlay(CardsTwo, "segunda"));
    }

    private void CheckCards(Card cOne, Card cTwo)
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

    private Card ChooseCardToPlay(List<Card> cards, string message)
    {
        int o = Random.Range(0, 100);
        Card card = new();

        if (o >= 75 || cards.Count <= 1)
        {
            foreach (Card c in cards)
            {
                if (c == Card.Emperor || c == Card.Slave)
                {
                    print($"{message} carta: {c}");
                    card = c;
                }
            }
        }
        else
        {
            foreach (Card c in cards)
            {
                if (c == Card.Citizen)
                {
                    print($"{message} carta: {c}");
                    card = c;
                    break;
                }
            }
        }


        if (card == Card.Emperor)
        {
            isEmperor = true;
        }
        else if (card == Card.Slave)
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
