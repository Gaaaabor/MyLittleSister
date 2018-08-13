using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeTrigger : MonoBehaviour {

    public void ChangeCamera(int v)
    {
        PlayerController.Instance.ChangeCameraPos(v);
    }
}
