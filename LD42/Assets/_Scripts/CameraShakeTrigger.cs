using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeTrigger : MonoBehaviour {

    public float Duration;
    public float Amount;

    public void Shake()
    {
        CameraShake.Instance.Shake(Duration,Amount);
    }
}
