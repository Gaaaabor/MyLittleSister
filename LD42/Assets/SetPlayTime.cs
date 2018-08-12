using UnityEngine;

public class SetPlayTime : MonoBehaviour
{
    public float TargetTime;
    public float Addtime;

    public void AddTime()
    {
        BuffManager.Instance.TimeBuffDuration += Addtime;
    }

    public void SetTime()
    {
        BuffManager.Instance.TimeBuffDuration = TargetTime;
    }
}
