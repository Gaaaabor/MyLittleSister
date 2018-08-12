using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChangeTrigger : MonoBehaviour
{
    public DayTime daytime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TimeManager.Instance.SetTime(daytime);
        }
    }
}
