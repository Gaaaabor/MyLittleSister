using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerHere : MonoBehaviour {

    public void Teleport()
    {
        PlayerController.Instance.transform.position = transform.position ;
        PlayerController.Instance.SetPlayerState(PlayerState.Walking);
    }
}
