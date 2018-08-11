using System;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : SingletonBase<BuffManager>
{
    private bool _timeChanged;
    private float _myTime;

    public float MyTime
    {
        get
        {
            return _myTime;
        }
        set
        {
            _myTime = value;
            TimeBuffText.text = _myTime.ToString("N1");
        }
    }

    public GameObject TimeBuffUi;
    public Text TimeBuffText;

    private void Awake()
    {
        TimeBuffUi.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_timeChanged)
        {
            MyTime -= (1 - Time.timeScale) * Time.unscaledDeltaTime;
            if (MyTime <= 0)
            {
                _timeChanged = false;
                MyTime = 0;
                TimeBuffUi.gameObject.SetActive(false);

                Time.timeScale = 1;
            }            
        }
    }

    public void ChangeTime(float time)
    {
        Time.timeScale = Math.Min(time, 1);
        _timeChanged = time != 1;
    }

    [ContextMenu("TestTime")]
    public void AddTime()
    {
        MyTime = 10;
        TimeBuffUi.gameObject.SetActive(true);
    }
}
