using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayTime : MonoBehaviour {

    public float Addtime;
    public float SetTime;

    public void AddTime(float value)
    {
        BuffManager.Instance.AddTime(value);
    }

	public void SetGlobalTime(float value)
    {
        Time.timeScale = value;
    }

    public void SetTimeBuff(float value)
    {
      //  BuffManager.Instance.SetTime(SetTime);
    }
}
