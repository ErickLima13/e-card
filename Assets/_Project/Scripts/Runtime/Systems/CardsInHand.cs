using System.Collections.Generic;
using UnityEngine;

public class CardsInHand : MonoBehaviour
{

    private float boundsSizeX = 2.04f;

    public CardsInHand()
    {
    }

    public void ArrangeCardsInHand(List<Transform> cardsPosition, Vector3 positionCard)
    {
        for (int i = 0; i < cardsPosition.Count; i++)
        {
            float newPositionX = i * boundsSizeX * 0.8f;
            positionCard.x = newPositionX - 3f;
            cardsPosition[i].transform.SetPositionAndRotation(positionCard, Quaternion.Euler(0, 0, positionCard.x * -1));
        }
    }
}
