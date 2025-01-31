using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;


public class OpponentIA : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    public List<BaseCard> cards = new();

    private BattleSystem _battleSystem;

    public Transform fieldPos;
    private BaseCard card;

    [Inject]
    private TurnControl turnControl;

    private async void Start()
    {
        _battleSystem = FindFirstObjectByType<BattleSystem>();

        for (int i = 0; i <= 4; i++)
        {
            GameObject c = Instantiate(cardPrefab, transform);
            cards.Add(c.GetComponent<BaseCard>());
        }

        for (int i = 0; i <= 4; i++)
        {
            cards[i].SetCardType(TypeCard.Citizen);
        }

        cards[cards.Count - 1].SetCardType(TypeCard.Emperor);

        for (int j = 0; j < cards.Count; j++)
        {
            float nx = j * cards[j].GetComponent<SpriteRenderer>().bounds.size.x * 0.5f;
            cards[j].transform.position = new(nx,transform.position.y,0);
        }

        await UniTask.WaitWhile(() => turnControl.currentState != GameState.OpponentTurn);

        PlayCard();
    }

    private void PlayCard()
    {
        _battleSystem.TakeOpponentCard(ChooseCardToPlay(cards, "oponente"));
    }

    private TypeCard ChooseCardToPlay(List<BaseCard> cards, string message)
    {
        int chance = Random.Range(0, 100);
        
        if (chance >= 75 || cards.Count <= 1)
        {
            foreach (BaseCard c in cards)
            {
                if (c.GetTypeOfCard() == TypeCard.Emperor || c.GetTypeOfCard() == TypeCard.Slave)
                {
                    print($"{message} carta: {c.GetTypeOfCard()}");
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
                    print($"{message} carta: {c}");
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
