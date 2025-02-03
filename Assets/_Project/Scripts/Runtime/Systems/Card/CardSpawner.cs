using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CardSpawner : MonoBehaviour
{
    public event Action<List<BaseCard>> OnCardAICreateEvent;

    private List<PlayerCard> playerCards = new();
    private List<BaseCard> cardsAI = new();

    [SerializeField] private PlayerCard cardPrefab;
    [SerializeField] private BaseCard baseCardPrefab;

    [SerializeField] private Transform handPosPlayer;
    [SerializeField] private Transform handPosAI;
    [SerializeField] private Vector3 posCard;

    [Inject]
    private readonly PlayerCardFactoryPlaceholder cardFactory;

    [Inject]
    private readonly TurnControl turnControl;

    [Inject]
    private readonly GameManager gameManager;


    private void OnEnable()
    {
        gameManager.OnFirstPlayerChooseEvent += CreateCards;
    }

    private void OnDisable()
    {
        gameManager.OnFirstPlayerChooseEvent -= CreateCards;
    }

    private void CreateCards()
    {
        CreateCitizensPlayer(TypeCard.Citizen, playerCards, cardPrefab);
        CreateCitizensAI(TypeCard.Citizen,cardsAI, baseCardPrefab);

        switch (turnControl.currentTurn.FirstPlayer == PlayerType.Player) // trocar devido regra de 3 rodadas.
        {
            case true:
                CreatePlayerCard(playerCards, cardPrefab, TypeCard.Emperor);
                CreateAICard(cardsAI, baseCardPrefab, TypeCard.Slave);
                break;
            case false:
                CreatePlayerCard(playerCards, cardPrefab, TypeCard.Slave);
                CreateAICard(cardsAI, baseCardPrefab, TypeCard.Emperor);
                break;
        }

        CardsInHand cardsInHand = new();
        cardsInHand.ArrangeCardsInHand(playerCards, posCard);
        cardsInHand.ArrangeCardsInHandAI(cardsAI, posCard * -1);

        OnCardAICreateEvent?.Invoke(cardsAI);
    }


    private void CreateCitizensPlayer(TypeCard typeCard, List<PlayerCard> playerCards, PlayerCard prefabPlayer)
    {
        for (int i = 0; i < 4; i++)
        {
            CreatePlayerCard(playerCards, prefabPlayer, typeCard);
        }
    }

    private void CreateCitizensAI(TypeCard typeCard,List<BaseCard> baseCards, BaseCard baseCardPrefab)
    {
        for (int i = 0; i < 4; i++)
        {
            CreateAICard(baseCards, baseCardPrefab, typeCard);
        }
    }

    private void CreateAICard(List<BaseCard> baseCards, BaseCard baseCard, TypeCard typeCard)
    {
        var AICard = Instantiate(baseCard, transform);
        AICard.transform.parent = handPosAI;
        AICard.SetCardType(typeCard);
        baseCards.Add(AICard);
        AICard.name = typeCard.ToString();
    }

    private void CreatePlayerCard(List<PlayerCard> playerCards, PlayerCard prefabPlayer, TypeCard typeCard)
    {
        var playerCard = cardFactory.Create(prefabPlayer);
        playerCard.SetCardType(typeCard);
        playerCard.transform.parent = handPosPlayer;
        playerCards.Add(playerCard);
        playerCard.name = typeCard.ToString();
    }
}
