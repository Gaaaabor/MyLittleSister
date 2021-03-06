﻿using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Vector3 _lookpos;

    private void Start()
    {
        if (Camera.main == null) return;
        _lookpos = Camera.main.transform.position - transform.position;
        _lookpos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(_lookpos);
        transform.rotation = rotation;
    }

    void Update()
    {
        if (Camera.main == null) return;
        _lookpos = Camera.main.transform.position - transform.position;
        _lookpos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(_lookpos);
        transform.rotation = rotation;
    }

    public void LookAtNow()
    {
        if (Camera.main == null) return;
        _lookpos = Camera.main.transform.position - transform.position;
        _lookpos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(_lookpos);
        transform.rotation = rotation;
    }
}
