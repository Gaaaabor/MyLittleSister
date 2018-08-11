using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour {

    public AudioClip Clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MusicManager.Instance.PlayMusic(Clip);
        }
    }
}
