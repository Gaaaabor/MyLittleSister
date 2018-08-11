using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLogic : MonoBehaviour {
    public bool StartOn;
    private bool _on;

    private void Awake()
    {
        if (!StartOn)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void Switch()
    {
        _on = !_on;
        gameObject.SetActive(_on);
    }
}
