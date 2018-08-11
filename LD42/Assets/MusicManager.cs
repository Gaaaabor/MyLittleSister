using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : SingletonBase<MusicManager>
{

    public AudioSource Primary;
    public AudioSource Secondary;

    public float lerpTime = 1;

    private bool _primary;
    private float _startVolume;

    private void Awake()
    {
        _startVolume = Primary.volume;
    }

    public void PlayMusic(AudioClip clip)
    {
        if (_primary)
        {
            Secondary.clip = clip;
            Secondary.Play();

            StartCoroutine(LerpVolume(0, Primary));
            StartCoroutine(LerpVolume(1, Secondary));
            _primary = false;
        }
        else
        {
            Primary.clip = clip;
            Primary.Play();

            StartCoroutine(LerpVolume(1, Primary));
            StartCoroutine(LerpVolume(0, Secondary));
            _primary = true;
        }
    }

    private IEnumerator LerpVolume(float newvolume, AudioSource audio)
    {
        var startVolume = audio.volume;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / lerpTime;

            audio.volume = Mathf.Lerp(startVolume, newvolume, t);

            yield return null;
        }
        if (newvolume ==0)
        {
            audio.Stop();
        }
        audio.volume = newvolume;
    }
}
