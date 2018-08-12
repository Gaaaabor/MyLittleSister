using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : SingletonBase<MusicManager>
{
    public AudioSource Primary;
    public AudioSource Secondary;

    public float lerpTime = 1;

    private bool _primary;

    public void PlayMusic(AudioClip clip, float volume)
    {

        if (Primary && _primary && Primary.clip != null)
        {
            if (Primary.clip.name == clip.name)
            {
                return;
            }
        }

        if (Secondary && !_primary&& Secondary.clip!=null)
        {
            if (Secondary.clip.name == clip.name)
            {
                return;
            }
        }

        if (_primary)
        {
            Secondary.clip = clip;
            Secondary.Play();
            StopAllCoroutines();
            StartCoroutine(LerpVolume(0, Primary));
            StartCoroutine(LerpVolume(volume, Secondary));
            _primary = false;
        }
        else
        {
            Primary.clip = clip;
            Primary.Play();
            StopAllCoroutines();
            StartCoroutine(LerpVolume(volume, Primary));
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
        if (newvolume == 0)
        {
            audio.Stop();
        }
        audio.volume = newvolume;
    }
}
