using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SunRotater : MonoBehaviour
{

    public Vector3Event RotateEvent;
    public float LerpSpeed;

    [Serializable]
    public class Vector3Event : UnityEvent<Vector3> { }

    public void SetRotation(Vector3 vector3, bool force = false)
    {
        if (force)
        {
            transform.localRotation = Quaternion.Euler(vector3);
            RotateEvent.Invoke(transform.rotation.eulerAngles);
            return;
        }
        StopAllCoroutines();
        StartCoroutine(C_SetRotation(vector3, LerpSpeed));
    }

    private IEnumerator C_SetRotation(Vector3 targetRot, float time)
    {
        var currentRot = transform.localRotation;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / time;

            transform.localRotation = Quaternion.Lerp(currentRot, Quaternion.Euler(targetRot), t);
            RotateEvent.Invoke(transform.rotation.eulerAngles);
            yield return null;
        }
        transform.localRotation = Quaternion.Euler(targetRot);
        RotateEvent.Invoke(transform.rotation.eulerAngles);

    }
}
