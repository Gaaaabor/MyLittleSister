using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayTimedLogicBase : MonoBehaviour
{
    public DayTime CurrentBehaviour;
    public UnityEvent DayEvent;
    public UnityEvent NightEvent;

    private void Awake()
    {
        AddTimed();
    }

    public void AddTimed()
    {
        if (TimeManager.Instance != null)
            TimeManager.Instance.AddDayTimed(this);
    }

    public void UpdateTimedBehaviour()
    {
        if (TimeManager.Instance == null) return;

        CurrentBehaviour = TimeManager.Instance.CurrentDayTime;

        switch (CurrentBehaviour)
        {
            case DayTime.DAY:
                ApplyDayBehaviour();
                break;
            case DayTime.NIGHT:
                ApplyNightBehaviour();
                break;
            default:
                break;
        }
    }

    public virtual void ApplyNightBehaviour()
    {
        if (CurrentBehaviour == DayTime.NIGHT) return;
        NightEvent.Invoke();
    }


    public virtual void ApplyDayBehaviour()
    {
        if (CurrentBehaviour == DayTime.DAY ) return;
        DayEvent.Invoke();
    }
}
