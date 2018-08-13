using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Curse : MonoBehaviour
{

    public int needed;
    public int current;
    public UnityEvent CompleteEvent;
    public UnityEvent StartCurseEvent;
    public GameObject CurseObject;
    public bool OnCurse;

    public List<ManagedGameObject> labels;

    private void Awake()
    {
        OnCurse = false;
        CurseObject.SetActive(false);
        current = 0;
    }

    [ContextMenu("StartCurse")]
    public void StartCurse()
    {
        Debug.Log("StartCurse");
        OnCurse = true;
        CurseObject.SetActive(true);
        StartCurseEvent.Invoke();
    }

    public void Reset()
    {
        foreach (var item in labels)
        {
            item.Restore();
        }
        OnCurse = false;
        CurseObject.SetActive(false);
        current = 0;
    }

    public void Increase()
    {
        current++;
        if (current >= needed)
        {
            Reset();
            CompleteEvent.Invoke();
        }
    }

    public void KillPlayer()
    {
        Reset();
        PlayerController.Instance.Die("CurseKill");
    }
}
