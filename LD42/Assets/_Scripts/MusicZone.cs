using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour {

    public AudioClip Clip;
    public float Volume = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MusicManager.Instance.PlayMusic(Clip, Volume);
        }
    }
}
