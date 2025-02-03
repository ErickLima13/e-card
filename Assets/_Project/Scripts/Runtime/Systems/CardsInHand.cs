using System.Collections.Generic;
using UnityEngine;

public class CardsInHand : MonoBehaviour
{

    

    public CardsInHand()
    {
    }

    private float boundsSizeX = 2.04f;

    public void ArrangeCardsInHand(List<PlayerCard> cards, Vector3 positionCard)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            float newPositionX = i * boundsSizeX * 0.8f;
            positionCard.x = newPositionX - 3f;
            cards[i].transform.SetPositionAndRotation(positionCard, Quaternion.Euler(0, 0, positionCard.x * -1));
        }
    }

    public void ArrangeCardsInHandAI(List<BaseCard> cards, Vector3 positionCard)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            float newPositionX = i * boundsSizeX * 0.8f;
            positionCard.x = newPositionX - 3f;
            cards[i].transform.SetPositionAndRotation(positionCard, Quaternion.Euler(0, 0, positionCard.x * -1));
        }
    }
}
