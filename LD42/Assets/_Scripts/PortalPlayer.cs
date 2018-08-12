using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPlayer : MonoBehaviour {

    public Transform otherPosition;

    private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Player")
        {
            //PlayerController.Instance.SetPosition(otherPosition.position);
        }
    }
}
