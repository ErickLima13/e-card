using System;
using UnityEngine;

public class StateMachineBase : MonoBehaviour
{
    public event Action OnEnterEvent;
    public event Action OnDoEvent;
    public event Action OnExitEvent;

    public virtual void Enter()
    {
        print(this.GetType().Name);
        OnEnterEvent?.Invoke();
    }

    public virtual void Do()
    {
        OnDoEvent?.Invoke();
    }

    public virtual void Exit()
    {
        OnExitEvent?.Invoke();
    }
}
