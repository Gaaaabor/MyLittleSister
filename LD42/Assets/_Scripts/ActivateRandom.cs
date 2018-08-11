using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRandom : MonoBehaviour
{
    public float minTime;
    public float maxTime;

    void Start()
    {
        gameObject.SetActive(false);
        Invoke("Activate", Random.Range(minTime, maxTime));
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        Destroy(this);
    }
}
