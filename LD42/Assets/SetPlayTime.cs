using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayTime : MonoBehaviour {

    public float TargetTime;
    public float Addtime;

    public void AddTime()
    {
        BuffManager.Instance.AddTime(Addtime);
    }

	public void SetTime()
    {
        BuffManager.Instance.ChangeTime(TargetTime);
    }
}
