using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class OpponentIA : MonoBehaviour
{

    public OpponentState state;

    public WaitState waitState;
    public ChooseCardState chooseCardState;
    public PlayCardState playCardState;

    [SerializeField] private Sprite backCard;


    private void Start()
    {

        waitState.Setup(this);
        chooseCardState.Setup(this);
        playCardState.Setup(this);

        ChangeState(waitState);

        //TakeCards(cardSpawner.CardsAI);
        //turnControl.OnPlayerTurnEndEvent += PlayCardAI;
        //cardSpawner.OnAIIsFirstPlayerEvent += PlayCardAI;


        //foreach (BaseCard card in cards)
        //{
        //    card.SetImageBack(backCard);
        //}
    }

    private void Update()
    {
        state.Do();
    }

    public void ChangeState(OpponentState newState)
    {
        state?.Exit();
        state = newState;
        state.Enter();
    }
}
