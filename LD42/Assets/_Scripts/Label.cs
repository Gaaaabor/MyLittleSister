using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour
{
    public Color EnabledColor = Color.white;
    public Color DisabledColor = Color.yellow;
    public Color DestroyColor = Color.red;
    public Transform LabelPlace;

    private GameObject _label;

    public void Awake()
    {
        _label = Instantiate(Resources.Load("Label"), transform.position + LabelPlace.transform.localPosition, Quaternion.identity) as GameObject;
        _label.transform.SetParent(transform);
        _label.GetComponentInChildren<Text>().text = GetComponent<ManagedGameObject>().ManagedName;
        GetComponentInParent<ManagedGameObject>().Label = this;
    }

    public void Destroyed()
    {
        _label.GetComponentInChildren<Text>().color = DestroyColor;
    }

    public void Disabled()
    {
        _label.GetComponentInChildren<Text>().color = DisabledColor;
    }

    public void Enabled()
    {
        _label.GetComponentInChildren<Text>().color = EnabledColor;
    }

    void Reset()
    {
        if (LabelPlace == null)
        {
            LabelPlace = new GameObject("LabelPlace").transform;
            LabelPlace.transform.SetParent(transform);
            LabelPlace.transform.localPosition = Vector3.zero;
        }
    }
}
