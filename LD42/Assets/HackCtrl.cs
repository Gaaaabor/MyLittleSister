using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackCtrl : MonoBehaviour
{

    public List<GameObject> ObjectsHack1;
    public List<GameObject> ObjectsHack2;
    public Material Base;
    public Material Hack1;
    public Material Hack2;

    [ContextMenu("Hack")]
    public void Hack()
    {
        foreach (var item in ObjectsHack1)
        {
            var rend = item.GetComponentInChildren<Renderer>();
            if (rend != null)
            {
                rend.material = Hack1;
            }
        }
        foreach (var item in ObjectsHack2)
        {
            var rend = item.GetComponentInChildren<Renderer>();
            if (rend != null)
            {
                rend.material = Hack2;
            }
        }
    }

    [ContextMenu("Repair")]
    public void Repair()
    {
        foreach (var item in ObjectsHack1)
        {
            var rend = item.GetComponentInChildren<Renderer>();
            if (rend != null)
            {
                rend.material = Base;
            }
        }
        foreach (var item in ObjectsHack2)
        {
            var rend = item.GetComponentInChildren<Renderer>();
            if (rend != null)
            {
                rend.material = Base;
            }
        }
    }
}
