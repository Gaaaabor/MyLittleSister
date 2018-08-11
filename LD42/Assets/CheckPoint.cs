using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private List<ManagedGameObject> _checkPointObject;

    private void Awake()
    {
        _checkPointObject = GetComponentInChildren<ManagedGameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().SetCheckPoint(this);
        }
    }

    public void ResetCheckPoint()
    {
    }
}
