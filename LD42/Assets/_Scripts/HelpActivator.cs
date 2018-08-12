using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpActivator : MonoBehaviour {

    public HelpType HelpType;

    public void Activatehelp()
    {
        HelpManager.Instance.AddHelp(HelpType);
    }
}
