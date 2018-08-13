using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidReseter : MonoBehaviour
{
    public Vector3 _lastPos;
    public Quaternion _lastRot;
    
    private void Awake()
    {
        _lastPos = transform.localPosition;
        _lastRot = transform.localRotation;
    }

    public void Reset()
    {
        transform.localPosition = _lastPos;
        transform.localRotation = _lastRot;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
