using UnityEngine;

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
