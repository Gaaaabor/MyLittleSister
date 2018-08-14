using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReseter : MonoBehaviour
{

    public void ResetPlayer()
    {
        PlayerController.Instance.ResetPlayer();
    }
}
