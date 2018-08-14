using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{ 
    public GameObject Core;
    public float ExplodeTime;
    public GameObject SubParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {         
            SubParticle.SetActive(true);
            Core.SetActive(false);        
            Invoke("Disable", ExplodeTime);
        }       
    }

    public void Reset()
    {     
        Core.SetActive(true);     
        SubParticle.SetActive(false);
    }
}
