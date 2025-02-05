using UnityEngine;
using Zenject;

public class OpponentState : MonoBehaviour
{
    protected OpponentIA opponentIA;

    [Inject]
    protected GameManager gameManager;
    [Inject]
    protected TurnControl turnControl;
    [Inject]
    protected CardSpawner cardSpawner;

    public virtual void Enter()
    {
        print(this.GetType().Name);
    }

    public virtual void Do()
    {
    }

    public virtual void FixedDo()
    {
    }

    public virtual void Exit()
    {
    }

    public void Setup(OpponentIA opponentIA)
    {
        this.opponentIA = opponentIA;
    }

}

