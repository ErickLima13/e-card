using System;
using UnityEngine;

public class PlayerField : MonoBehaviour
{
    public event Action<TypeCard> OnCardIsPlayedEvent;

    public void CardIsSet(TypeCard typeCard)
    {
        OnCardIsPlayedEvent?.Invoke(typeCard);
    }
}
