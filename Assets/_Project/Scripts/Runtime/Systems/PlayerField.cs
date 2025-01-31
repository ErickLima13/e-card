using System;
using UnityEngine;

public class PlayerField : MonoBehaviour
{
    public event Action<TypeCard> OnCardIsPlayedEvent;

    private Collider2D detectCol;

    private void Start()
    {
        detectCol = GetComponent<Collider2D>();
    }


    public void CardIsSet(TypeCard typeCard)
    {
        OnCardIsPlayedEvent?.Invoke(typeCard);
        detectCol.enabled = false;
    }
}
