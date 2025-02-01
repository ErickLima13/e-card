using System;
using UnityEngine;
using Zenject;

public class PlayerField : MonoBehaviour
{

    private Collider2D detectCol;

    [Inject]
    public TurnControl turnControl;

    private void Start()
    {
        detectCol = GetComponent<Collider2D>();
    }


    public void CardIsSet(TypeCard typeCard)
    {
        turnControl.PlayCard(PlayerType.Player, typeCard);
        // detectCol.enabled = false;
    }
}
