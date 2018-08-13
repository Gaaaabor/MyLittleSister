using UnityEngine;
using System.Collections;
using System;

public class SunController : MonoBehaviour
{

    public Light _moonlight;

    public float _rotationOffset; // use this offset to sync sun rotation with clock time

    public Gradient nightDayColor;
    public AnimationCurve nightDayIntensity;

    public AnimationCurve nightDayAmbientIntensity;

    public AnimationCurve nightDayMoonIntensity;
    public Gradient nightDayMoonColor;

    public AnimationCurve starsAlpha;
    public Gradient cloudColor;

    public Gradient _tintColor;

    public Gradient _ambientSkyColor;
    public Gradient _ambientEquatorColor;
    public Gradient _ambientGroundColor;

    private Color _starColor = new Color(1f, 1f, 1f, 1f);

    public AnimationCurve _backgroundDayWeight;
    public AnimationCurve _backgroundNoonWeight;
    public AnimationCurve _backgroundNightWeight;
    public Color DarkColor;
    Light mainLight;
    Skybox sky;
    Material skyMat;

    void Awake()
    {
        mainLight = GetComponent<Light>();
        skyMat = RenderSettings.skybox;

        //RenderSettings.ambientIntensity = 0f;
        //RenderSettings.ambientLight = Color.black;
    }

    public void OnPlanetRotationChanged(Vector3 vector)
    {
        float angle = vector.y;
        // TODO: improve communication between widget and this.
        // need a more meaningful value for the planet rotation in order to set all this up
        float lerpValue = angle / 360f;
        //Debug.Log ("Angle: " + angle + " - Time: " + Mathf.FloorToInt(angle/15f)); // to get value [0-23]

        mainLight.transform.localRotation = Quaternion.Euler(angle + _rotationOffset, 0, 0);

        mainLight.color = nightDayColor.Evaluate(lerpValue);

        float sunIntensity = nightDayIntensity.Evaluate(lerpValue);
        mainLight.intensity = sunIntensity;


        //RenderSettings.ambientIntensity = nightDayAmbientIntensity.Evaluate(lerpValue);
        //Debug.Log ("Ambient intensity: " + RenderSettings.ambientIntensity);


        // MOON LIGHT
        _moonlight.color = nightDayMoonColor.Evaluate(lerpValue);
        _moonlight.intensity = nightDayMoonIntensity.Evaluate(lerpValue);

        //RenderSettings.fogColor = nightDayFogColor.Evaluate(lerpValue);
        //RenderSettings.fogDensity = fogDensityCurve.Evaluate(lerpValue) * fogScale;

        //float thickness = ((dayAtmosphereThickness - nightAtmosphereThickness) * nightDayAtmosphereThickness.Evaluate(lerpValue)) + nightAtmosphereThickness;
        //Debug.Log ("Atmosphere thcickness: " + thickness);
        Color tintColor = _tintColor.Evaluate(lerpValue);
        skyMat.SetColor("_Tint", tintColor);

        //_background.material.SetFloat ("_Weight1", _backgroundDayWeight.Evaluate(lerpValue));

        RenderSettings.ambientSkyColor = _ambientSkyColor.Evaluate(lerpValue);
        RenderSettings.ambientEquatorColor = _ambientEquatorColor.Evaluate(lerpValue);
        RenderSettings.ambientGroundColor = _ambientGroundColor.Evaluate(lerpValue);

    }

    internal void SetDark()
    {
        _moonlight.enabled = false;
        RenderSettings.ambientSkyColor = DarkColor;
    }
}
