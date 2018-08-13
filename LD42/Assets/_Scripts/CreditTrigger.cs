using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditTrigger : MonoBehaviour {
    
	public void ChangeCredit(bool v)
    {
        CreditManager.Instance.ChangeCredit(v);
    }
}
