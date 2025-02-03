using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class OpponentIA : MonoBehaviour
{
    public List<BaseCard> cards = new();

    public Transform fieldPos;
    private BaseCard card;

    [Inject]
    private TurnControl turnControl;

    [Inject]
    private CardSpawner cardSpawner;

    [SerializeField] private Sprite backCard;


    private void Start()
    {
        cardSpawner.OnCardAICreateEvent += TakeCards;

        //foreach (BaseCard card in cards)
        //{
        //    card.SetImageBack(backCard);
        //}
    }

    private void OnDisable()
    {
        cardSpawner.OnCardAICreateEvent -= TakeCards;
    }

    private void Update()
    {
        //if (turnControl.currentBattleState == BattleState.SecondPlayer)
        //{
        //    PlayCard();
        //}
    }

    private void PlayCard()
    {
        turnControl.PlayCard(PlayerType.AI, ChooseCardToPlay(cards));
    }

    private void TakeCards(List<BaseCard> baseCardList)
    {
        cards = baseCardList;
    }

    private TypeCard ChooseCardToPlay(List<BaseCard> cards)
    {
        int chance = Random.Range(0, 100);

        if (chance >= 75 || cards.Count <= 1)
        {
            foreach (BaseCard c in cards)
            {
                if (c.GetTypeOfCard() == TypeCard.Emperor || c.GetTypeOfCard() == TypeCard.Slave)
                {
                    card = c;
                }
            }
        }
        else
        {
            foreach (BaseCard c in cards)
            {
                if (c.GetTypeOfCard() == TypeCard.Citizen)
                {
                    card = c;
                    break;
                }
            }
        }

        int id = cards.IndexOf(card);
        cards[id].transform.position = fieldPos.position;
        cards.Remove(card);
        return card.GetTypeOfCard();
    }
}
