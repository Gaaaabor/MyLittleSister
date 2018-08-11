using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableEvents : MonoBehaviour
{
    public List<SpriptableEvent> eventList;
    public List<SpriptableEvent> firedEvent;

    private bool _on;
    private float _timer;

    private void Start()
    {
        eventList = eventList.OrderBy(x => x.Timestemp).ToList();
    }

    private void Update()
    {
        if (_on)
        {
            _timer += Time.deltaTime;
            if (eventList.FirstOrDefault() != null && eventList.FirstOrDefault().Timestemp <= _timer)
            {
                ShotNextEvent();
            }
        }
    }

    private void ShotNextEvent()
    {
        var nextevent = eventList.FirstOrDefault();
        nextevent.Event.Invoke();
        firedEvent.Add(nextevent);
        eventList.Remove(nextevent);
    }

    public void StartTimer()
    {
        _on = true;
    }

    public void PauseTimer()
    {
        _on = false;
    }

    [ContextMenu("ResetAndStart")]
    public void ResetAndStart()
    {
        ResetEvents();
        StartTimer();
    }

    public void ResetEvents()
    {
        foreach (var item in firedEvent)
        {
            eventList.Add(item);
        }
        firedEvent.Clear();

        eventList = eventList.OrderBy(x => x.Timestemp).ToList();
        _on = false;
        _timer = 0;
    }
}

[Serializable]
public class SpriptableEvent
{
    public string Id;
    public float Timestemp;
    public UnityEvent Event;
}