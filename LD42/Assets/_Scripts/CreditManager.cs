using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditManager : SingletonBase<CreditManager> {

    public GameObject Cretit;
    public Text scrore;


    public override void Awake()
    {
        ChangeCredit(false);
    }

    public void ChangeCredit(bool v)
    {
        Cretit.SetActive(v);

        scrore.text = "Your score: " + (1000 - SpaceCounter.Instance.SpaceCount).ToString();
    }
}
