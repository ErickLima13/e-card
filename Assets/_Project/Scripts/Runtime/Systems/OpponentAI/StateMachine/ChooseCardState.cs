using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCardState : OpponentState
{
    private List<BaseCard> mCards = new();
    private BaseCard card;

    public override void Do()
    {
        base.Do();
    }

    public override async void Enter()
    {
        base.Enter();

        TakeCards(cardSpawner.GetAICards());

        await UniTask.WaitUntil(() => mCards.Count > 0);

        opponentIA.ChangeState(opponentIA.playCardState);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    private void TakeCards(List<BaseCard> baseCardList)
    {
        mCards = baseCardList;
    }

    public TypeCard ChooseCardToPlay()
    {
        int chance = Random.Range(0, 100);

        if (chance >= 75 || mCards.Count <= 1)
        {
            foreach (BaseCard c in mCards)
            {
                if (c.GetTypeOfCard() == TypeCard.Emperor || c.GetTypeOfCard() == TypeCard.Slave)
                {
                    card = c;
                }
            }
        }
        else
        {
            foreach (BaseCard c in mCards)
            {
                if (c.GetTypeOfCard() == TypeCard.Citizen)
                {
                    card = c;
                    break;
                }
            }
        }

        print(card.GetTypeOfCard());
        return card.GetTypeOfCard();
    }

    public void RemoveCardOfList(TypeCard type)
    {
        for (int i = 0; i < mCards.Count; i++)
        {
            if (mCards[i].GetTypeOfCard() == type)
            {
                mCards.RemoveAt(i);
                return;
            }
        }
    }

    public void SetCardInField(Transform target)
    {
        int id = mCards.IndexOf(card);
        float duration = 0.5f;

        var sequence = DOTween.Sequence();

        sequence.Append(mCards[id].transform.DOJump(target.position, 2f, 1,duration));
        sequence.Append(mCards[id].transform.DORotate(Vector3.zero, duration, RotateMode.Fast));
        sequence.Append(mCards[id].transform.DOShakePosition(duration));
    }
    
}
