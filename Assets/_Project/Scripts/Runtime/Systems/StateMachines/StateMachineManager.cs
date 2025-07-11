using System;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    [SerializeField] private StateMachineBase[] _statesBase;

    public T GetState<T>() where T : StateMachineBase
    {
        T state = null;
        foreach (var st in _statesBase)
        {
            if (st is T)
            {
                state = st as T;
                break;
            }
        }

        return state;
    }
}
