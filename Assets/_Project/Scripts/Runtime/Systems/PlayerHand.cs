using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHand : MonoBehaviour
{
    private List<PlayerCard> cards = new();

    [SerializeField] private PlayerCard cardPrefab;
    [SerializeField] private Transform handPos;
    [SerializeField] private Vector3 posCard;

    [Inject]
    private PlayerCardFactoryPlaceholder cardFactory;

    [Inject]
    private TurnControl turnControl;

    private void Start()
    {
        turnControl.CreateTurn(PlayerType.Player);

        for (int i = 0; i <= 4; i++)
        {
            var playerCard = cardFactory.Create(cardPrefab);
            playerCard.transform.parent = handPos;
            cards.Add(playerCard);
        }

        for (int i = 0; i <= 4; i++)
        {
            cards[i].SetCardType(TypeCard.Citizen);
        }

        cards[cards.Count - 1].SetCardType(TypeCard.Slave);

        for (int i = 0; i < cards.Count; i++)
        {
            float newPositionX = i * cards[i].GetComponent<SpriteRenderer>().bounds.size.x * 0.8f;
            posCard.x = newPositionX - 3f;
            cards[i].transform.SetPositionAndRotation(posCard, Quaternion.Euler(0, 0, posCard.x * -1));
        }

    }
}
