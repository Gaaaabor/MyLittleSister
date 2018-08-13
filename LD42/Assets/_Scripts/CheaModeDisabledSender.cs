using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheaModeDisabledSender : MonoBehaviour {

	public void SendDisabled()
    {
        CheatmodeDisabledReceiver.Instance.Disable();
    }
}
