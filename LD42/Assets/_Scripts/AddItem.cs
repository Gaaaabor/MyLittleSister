using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {

	public void AddSword()
    {
        PlayerController.Instance.SetSword(true);
    }

    public void AddTorch()
    {
        PlayerController.Instance.SetTorch(true);
    }

    public void AddPrincess()
    {
        PlayerController.Instance.SetPrincess(true);
    }

    public void RemovePrincess()
    {
        PlayerController.Instance.SetPrincess(false);
    }
}
