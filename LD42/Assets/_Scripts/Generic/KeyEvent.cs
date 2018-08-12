using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyEvent : MonoBehaviour {

    public KeyCode key;
   public UnityEvent Event;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Event.Invoke();
        }
    }
}
