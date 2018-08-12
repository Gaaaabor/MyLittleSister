using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnAwake : MonoBehaviour {

    void Awake()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }
}
