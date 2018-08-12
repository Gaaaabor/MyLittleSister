using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    public bool StartStart;
    public int Time;
    public UnityEvent Event;

    public void Start()
    {
        if (StartStart)
            Invoke("InvokeEvent", Time);
    }

    public void StartTimer()
    {
        Invoke("InvokeEvent", Time);
    }

    public void InvokeEvent()
    {
        Event.Invoke();
    }

    public void StopEvent()
    {
        CancelInvoke();
    }
}
