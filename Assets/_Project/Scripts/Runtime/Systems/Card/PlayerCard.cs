using DG.Tweening;
using UnityEngine;
using Zenject;

public class PlayerCard : BaseCard, IInteractiveObject
{
    public bool isOnPlayerField;

    private Vector3 _startPosition;
    private Collider2D _collider;
    private PlayerField _field;

    private void Start()
    {
        _startPosition = transform.position;
        _collider = GetComponent<Collider2D>();
    }

    public void MoveToPosition(Vector3 pointClick)
    {
        transform.DOJump(pointClick,2f,1,0.5f);
    }

    public void Drop(Vector2 pointClick)
    {
        if (isOnPlayerField)
        {
            if (_field != null)
            {
                MoveToPosition(_field.transform.position);
                SetImageBack();
                _field.CardIsSet(GetTypeOfCard(),this);
                _collider.enabled = false;
                transform.DORotate(Vector3.zero, 0.5f, RotateMode.Fast);
            }
        }
        else
        {
            MoveToPosition(_startPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOnPlayerField = true;
        _field = collision.GetComponent<PlayerField>();
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    isOnPlayerField = true;
    //    _field = collision.GetComponent<PlayerField>();
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnPlayerField = false;
        _field = null;
    }
}
