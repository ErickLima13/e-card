using System.Collections.Generic;
using UnityEngine;

public class OpponentIA : MonoBehaviour
{
    public List<TypeCard> CardsOne = new();


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

        cards.Remove(card);
        return card;
    }
}
