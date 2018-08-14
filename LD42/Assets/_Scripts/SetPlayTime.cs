using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayTime : MonoBehaviour
{
    public void AddTime(float value)
    {
        BuffManager.Instance.TimeBuffDuration += value;
    }

    public void SetGlobalTime(float value)
    {

        Time.timeScale = value;
    }
    public void LockTime()
    {
        Time.timeScale = 0;
        BuffManager.Instance.LockTime();
    }

    public void SetTimeBuff(float value)
    {
        BuffManager.Instance.TimeBuffDuration = value;
        BuffManager.Instance.TimeBuffText.text = BuffManager.Instance.TimeBuffDuration.ToString("N2");
    }
}
