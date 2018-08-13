using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCheatManager : SingletonBase<DisableCheatManager>
{
    public GameObject Cheat;
    public void StartDisableCheat()
    {
        Cheat.SetActive(true);
    }
}
