using UnityEngine;

public class ChangePlayerState : MonoBehaviour
{
    public PlayerState StateToChange;

    public void ChangeState()
    {
        PlayerController.Instance.SetPlayerState(StateToChange);
    }

}
