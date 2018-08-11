using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public List<ManagedGameObject> CheckPointObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.SetCheckPoint(this);
        }
    }

    public void ResetCheckPoint()
    {
        foreach (var item in CheckPointObject)
        {
            item.Restore();
        }
    }
}
