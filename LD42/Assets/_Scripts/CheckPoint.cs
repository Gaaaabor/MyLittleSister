using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public List<ManagedGameObject> CheckPointObject;
    public UnityEvent CheckpointEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.SetCheckPoint(this);
        }
    }

    public void ResetCheckPoint()
    {
        CheckpointEvent.Invoke();
        foreach (var item in CheckPointObject)
        {
            item.Restore();
        }
    }
}
