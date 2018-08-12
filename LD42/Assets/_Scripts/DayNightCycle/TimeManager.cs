using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : SingletonBase<TimeManager>
{
    public DayTime StartDaytime;

    // these are used for triggering events when dya or night starts
    [Range(0, 23)]
    public int dayStartTime;
    private float dayStartAngle;

    [Range(0, 21)]
    public int nightStartTime;
    private float nightStartAngle;
    public SunController sunController;
    public SunRotater Sun;

    private List<DayTimedLogicBase> _dayTimeds = new List<DayTimedLogicBase>();
    private float _time;

    public UnityEvent TimeChangedEvent;

    public float CurrentAngle
    {
        get { return _time; }
    }

    private DayTime _dayTime;

    public DayTime CurrentDayTime
    {
        get { return _dayTime; }
    }
    public float CurrentTime
    {
        get { return _time / 15f; }
    }

    public void AddDayTimed(DayTimedLogicBase dayTimed)
    {
        if (!_dayTimeds.Contains(dayTimed))
            _dayTimeds.Add(dayTimed);
    }

    public void RemoveDayTimed(DayTimedLogicBase dayTimed)
    {
        _dayTimeds.Remove(dayTimed);
    }

    public void Start()
    {
        dayStartAngle = (dayStartTime - 2) * 15f;
        nightStartAngle = (nightStartTime - 2) * 15f;

        switch (StartDaytime)
        {
            case DayTime.DAY:
                Sun.SetRotation(new Vector3(0, dayStartTime * 15, 0), true);
                break;
            case DayTime.NIGHT:
                Sun.SetRotation(new Vector3(0, nightStartTime * 15, 0), true);
                break;
            default:
                break;
        }
    }

    public void SetTime(DayTime daytime)
    {
        switch (daytime)
        {
            case DayTime.DAY:
                _time = dayStartTime * 15f;
                SetDay();
                break;
            case DayTime.NIGHT:
                _time = nightStartTime * 15f;
                SetNight();
                break;
            default:
                break;
        }
    }

    [ContextMenu("SetDay")]
    public void SetDay()
    {
        SetTime(dayStartTime);

    }

    [ContextMenu("SetNight")]
    public void SetNight()
    {
        SetTime(nightStartTime);
    }

    public void SetTime(float time)
    {
        Sun.SetRotation(new Vector3(0, time * 15, 0));
    }

    // convert 0-23hs to 0-360 degrees
    public void ChangeTime(Vector3 planet)
    {
        _time = Mathf.Abs(planet.y % 360);
        sunController.OnPlanetRotationChanged(planet);
        CheckDayNightStarted();
    }

    private void CheckDayNightStarted()
    {
        if (_time >= dayStartAngle && _time <= nightStartAngle && _dayTime == DayTime.NIGHT)
        {
            _dayTime = DayTime.DAY;
            OnDayStarted();
        }
        else
            if ((_time < dayStartAngle || _time >= nightStartAngle) && _dayTime == DayTime.DAY)
        {
            _dayTime = DayTime.NIGHT;
            OnNightStarted();
        }
    }

    private void OnNightStarted()
    {
        foreach (var item in _dayTimeds)
        {
            item.UpdateTimedBehaviour();
        }
    }

    private void OnDayStarted()
    {
        foreach (var item in _dayTimeds)
        {
            item.UpdateTimedBehaviour();
        }
    }
}

public enum DayTime
{
    DAY,
    NIGHT,
}