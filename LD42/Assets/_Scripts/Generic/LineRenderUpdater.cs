using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRenderUpdater : MonoBehaviour
{
    private LineRenderer _line;

    public Transform TargetTransform;

    void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, TargetTransform.position);
    }
}
