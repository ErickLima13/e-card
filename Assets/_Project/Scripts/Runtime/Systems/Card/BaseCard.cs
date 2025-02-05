using UnityEngine;

public class BaseCard : MonoBehaviour
{
    private SpriteRenderer sRenderer;
    [SerializeField] protected Sprite[] sprites;

    [SerializeField] private Sprite backCard;

    private TypeCard _cardType;

    private void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetCardType(TypeCard cardType)
    {
        _cardType = cardType;
        SetCardImage();
    }

    protected void SetCardImage()
    {
        switch (_cardType)
        {
            case TypeCard.Citizen:
                sRenderer.sprite = sprites[0];
                break;
            case TypeCard.Emperor:
                sRenderer.sprite = sprites[1];
                break;
            case TypeCard.Slave:
                sRenderer.sprite = sprites[2];
                break;
        }
    }

    public TypeCard GetTypeOfCard()
    {
        return _cardType;
    }

    public void SetImageBack()
    {
        sRenderer.sprite = backCard;
    }

    public void RevealCard()
    {

    }
}
