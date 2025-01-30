using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    public List<PlayerCard> cards = new();

    public Transform handPos;

    public Vector3 posCard;

    private void Start()
    {
        for (int i = 0; i <= 4; i++)
        {
            GameObject c = Instantiate(cardPrefab, handPos);
            cards.Add(c.GetComponent<PlayerCard>());
        }

        for (int i = 0; i <= 4; i++)
        {
            cards[i].SetCardType(TypeCard.Citizen);
        }

        cards[cards.Count - 1].SetCardType(TypeCard.Slave);

        for (int j = 0; j < cards.Count; j++)
        {
            float nx = j * cards[j].GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
            posCard.x = nx;
            cards[j].transform.position = posCard;
        }

    }
}
