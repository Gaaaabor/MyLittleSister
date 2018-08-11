using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EasyPosition : MonoBehaviour {
    public EasyPosType EasyPosType;
    public Vector3 OffsetFromNormal;
}
public enum EasyPosType
{
    Forward,
    Up,
    Down,
    Backward,
    Right,
    Left,
}