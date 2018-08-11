using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour
{
    public Transform LabelPlace;

    private GameObject _label;
    private Animator _anim;

    public void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _label = Instantiate(Resources.Load("Label"), transform.position + LabelPlace.transform.localPosition, Quaternion.identity) as GameObject;
        _label.transform.SetParent(transform);
        _label.GetComponentInChildren<Text>().text = GetComponent<ManagedGameObject>().ManagedName;
        GetComponentInParent<ManagedGameObject>().Label = this;
    }

    public void ShowLabel()
    {
        _anim.SetBool("Show",true);
    }

    public void HideLabel()
    {
        _anim.SetBool("Show", false);
    }

    public void Destroyed()
    {
        _anim.SetInteger("State",0);
    }

    public void Disabled()
    {
        _anim.SetInteger("State", 1);
    }

    public void Enabled()
    {
        _anim.SetInteger("State", 2);
    }

    public void Activate()
    {
        _anim.SetTrigger("Activate");
    }

    void Reset()
    {
        if (LabelPlace == null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).name == "LabelPlace")
                {
                    LabelPlace = transform.GetChild(i);
                    return;
                }
            }
            LabelPlace = new GameObject("LabelPlace").transform;
            LabelPlace.transform.SetParent(transform);
            LabelPlace.transform.localPosition = Vector3.zero;
        }
    }
}
