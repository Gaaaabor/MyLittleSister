using UnityEngine;
using System.Collections;

public class Flickering_Light : MonoBehaviour
{
    public Light flickerLight;
    public Color originalColor;
    public float intensityChange = 0.5f;
    float minFlickerIntensity;
    float maxFlickerIntensity;
    public float flickerSpeed = 0.035f;

    private int randomizer = 0;

    private void Start()
    {
        minFlickerIntensity = flickerLight.intensity - intensityChange;
        maxFlickerIntensity = flickerLight.intensity + intensityChange;
        Flick();
    }
    private void Flick()
    {
        float intensity = (Random.Range(minFlickerIntensity, maxFlickerIntensity));

        float nextTime = Random.Range(flickerSpeed - 0.2f, flickerSpeed + 0.2f);
        if (nextTime < 0)
        {
            nextTime = 0;
        }
        StartCoroutine(C_Flick(nextTime, intensity));
    }

    private IEnumerator C_Flick(float time, float intensity)
    {
        var currentIntensity = flickerLight.intensity;

        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / time;

            flickerLight.intensity = Mathf.Lerp(currentIntensity,intensity,t);
            yield return null;
        }
        flickerLight.intensity = intensity;
        Flick();
    }
}