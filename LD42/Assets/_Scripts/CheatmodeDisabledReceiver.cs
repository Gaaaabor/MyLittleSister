using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheatmodeDisabledReceiver : SingletonBase<CheatmodeDisabledReceiver> {

    public UnityEvent DisableEvent;

    public void Disable()
    {
        DisableEvent.Invoke();
    }
}
