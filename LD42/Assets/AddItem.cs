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
}
