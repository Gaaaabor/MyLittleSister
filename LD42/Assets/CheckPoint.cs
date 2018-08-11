using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private List<ManagedGameObject> _checkPointObject;

    private void Awake()
    {
        _checkPointObject = GetComponentsInChildren<ManagedGameObject>().ToList();
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
