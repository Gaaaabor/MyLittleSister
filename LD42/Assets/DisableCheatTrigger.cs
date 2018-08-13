using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCheatTrigger : MonoBehaviour
{
    public void StartDisableCheat()
    {
        DisableCheatManager.Instance.StartDisableCheat();
    }
}
