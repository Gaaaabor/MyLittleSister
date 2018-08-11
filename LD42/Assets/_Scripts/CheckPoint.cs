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
            PlayerController.Instance.SetCheckPoint(this);
        }
    }

    public void ResetCheckPoint()
    {
        foreach (var item in _checkPointObject)
        {
            item.Restore();
        }
    }
}
