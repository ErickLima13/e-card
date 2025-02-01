using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public GameState currentGameState;

    private List<PlayerCard> playerCards = new();

    [SerializeField] private PlayerCard cardPrefab;
    [SerializeField] private Transform handPosPlayer;
    [SerializeField] private Transform handPosAI;
    [SerializeField] private Vector3 posCard;
    [SerializeField] private BaseCard baseCardPrefab;

    public List<BaseCard> cardsAI = new();

    [Inject]
    private PlayerCardFactoryPlaceholder cardFactory;

    [Inject]
    private TurnControl turnControl;


    private void Start()
    {
        ChangeGameState(GameState.ChooseFirstPlayer);
        ChooseFisrtPlayer();
        CreateCards();
    }

    private void CreateCards()
    {
        CreateCitizens(true,TypeCard.Citizen,playerCards,null,cardPrefab);
        CreateCitizens(false,TypeCard.Citizen, null, cardsAI, null, baseCardPrefab);

        switch (turnControl.currentTurn.FirstPlayer == PlayerType.Player)
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


  


    }

    private void CreateCitizens(bool isPlayer,TypeCard typeCard, List<PlayerCard> playerCards = null, List<BaseCard> baseCards = null, 
        PlayerCard prefabPlayer = null, BaseCard baseCard = null)
    {
        if (isPlayer)
        {
            for (int i = 0; i < 4; i++)
            {
                CreatePlayerCard(playerCards, prefabPlayer,typeCard);
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                CreateAICard(baseCards, baseCard,typeCard);
            }
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

    private void CreatePlayerCard(List<PlayerCard> playerCards, PlayerCard prefabPlayer,TypeCard typeCard)
    {
        var playerCard = cardFactory.Create(prefabPlayer);
        playerCard.SetCardType(typeCard);
        playerCard.transform.parent = handPosPlayer;
        playerCards.Add(playerCard);
        playerCard.name = typeCard.ToString();
    }

    private void ChooseFisrtPlayer()
    {
        int rand = Random.Range(0, 100);

        if (rand % 2 == 0)
        {
            turnControl.CreateTurn(PlayerType.Player);         
        }
        else
        {
            turnControl.CreateTurn(PlayerType.AI);
        }

        ChangeGameState(GameState.ArrangeCards);
    }

    private void ChangeGameState(GameState newState)
    {
        if (currentGameState != newState)
        {
            currentGameState = newState;
        }
    }

}
