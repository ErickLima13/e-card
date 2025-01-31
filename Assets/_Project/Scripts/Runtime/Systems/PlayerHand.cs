using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private PlayerCard cardPrefab;
    public List<PlayerCard> cards = new();

    public Transform handPos;

    public Vector3 posCard;

    [SerializeField] [Inject] private PlayerCardFactoryPlaceholder cardFactory;

    private void Start()
    {
        for (int i = 0; i <= 4; i++)
        {
            var playerCard = cardFactory.Create(cardPrefab);
            playerCard.transform.position = handPos.position;
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
            posCard.x = newPositionX;
            cards[i].transform.position = posCard;
        }

    }
}
