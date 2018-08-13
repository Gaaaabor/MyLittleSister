using System.Collections;
using UnityEngine;

public class CameraShake : SingletonBase<CameraShake>
{
    public float TestDuration;
    public float TestIntensity;
    public AudioSource shakeaudio;
    private Vector3 _originalPos;

    public override void Awake()
    {
        base.Awake();      
        shakeaudio.loop = true;
    }

    [ContextMenu("TestShake")]
    public void TestShake()
    {
        Shake(TestDuration, TestIntensity);
    }

    public void Shake(float duration, float amount)
    {
        _originalPos = PlayerController.Instance.CurrentCam.localPosition;
        StopAllCoroutines();
        shakeaudio.Play();
        StartCoroutine(cShake(duration, amount));
    }

    private IEnumerator cShake(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }
        shakeaudio.Stop();
        transform.localPosition = _originalPos;
    }
}