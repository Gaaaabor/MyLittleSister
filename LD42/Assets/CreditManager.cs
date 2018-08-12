using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : SingletonBase<CreditManager> {

    public GameObject Cretit;

    public override void Awake()
    {
        ChangeCredit(false);
    }

    public void ChangeCredit(bool v)
    {
        Cretit.SetActive(v);
    }
}
