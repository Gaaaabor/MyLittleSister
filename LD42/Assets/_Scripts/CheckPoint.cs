using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public List<ManagedGameObject> CheckPointObject;
    public UnityEvent CheckpointEvent;
    public float CheckpointTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.SetCheckPoint(this);
            CheckpointTime = BuffManager.Instance.TimeBuffDuration;
        }
    }

    public void ResetCheckPoint()
    {
        CheckpointEvent.Invoke();
        foreach (var item in CheckPointObject)
        {
            if (item != null)
                item.Restore();
        }
        BuffManager.Instance.TimeBuffDuration = CheckpointTime;
        BuffManager.Instance.TimeBuffText.text = BuffManager.Instance.TimeBuffDuration.ToString("N2");
    }
}
