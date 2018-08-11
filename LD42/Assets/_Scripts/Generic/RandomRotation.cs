using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RandomRotation : MonoBehaviour
{
    public float MinScale = 2.5f;
    public float MaxScale = 4f;

    void Start()
    {
#if UNITY_EDITOR
        this.transform.Rotate(0, Random.Range(0, 360), 0);
        float scale = Random.Range(MinScale, MaxScale);
        this.transform.localScale = new Vector3(scale, scale, scale);
        DestroyImmediate(this);
#endif
    }
}