using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseTrigger : MonoBehaviour
{
    public float Time;
    public void Activate()
    {
        BuffManager.Instance.CaseSensitivenessBuffDuration = Time;
        BuffManager.Instance.CaseSensitivenessBuffIsActive = true;
    }
}
