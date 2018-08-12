using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : SingletonBase<HelpManager>
{

    public bool HelpOn;
    public GameObject HelpPanel;

    public GameObject Enable;
    public GameObject Disable;
    public GameObject Activate;
    public GameObject Kill;
    public GameObject EnableFast;
    public GameObject DisableFast;
    public GameObject KillFast;
    public GameObject ActivateFast;
    public GameObject Speed;
    public GameObject SpeedFast;


    public void Awake()
    {
        HelpPanel.SetActive(false);
        Enable.SetActive(false);
        Disable.SetActive(false);
        Activate.SetActive(false);
        Kill.SetActive(false);
        EnableFast.SetActive(false);
        DisableFast.SetActive(false);
        KillFast.SetActive(false);
        ActivateFast.SetActive(false);
        Speed.SetActive(false);
        SpeedFast.SetActive(false);
    }

    public void ChangeHelp()
    {
        HelpOn = !HelpOn;

        UpdatePanel();
    }

    private void UpdatePanel()
    {
        HelpPanel.SetActive(HelpOn);
    }

    public void AddHelp(HelpType helpType)
    {
        switch (helpType)
        {
            case HelpType.Enable:               
                Enable.SetActive(false);
                break;
            case HelpType.Disable:
              
                Disable.SetActive(true);
                break;
            case HelpType.Kill:
                Kill.SetActive(true);
                break;
            case HelpType.Activate:
                Activate.SetActive(true);
                break;
            case HelpType.FastTypes:
                EnableFast.SetActive(true);
                DisableFast.SetActive(true);
                KillFast.SetActive(true);
                ActivateFast.SetActive(true);
                SpeedFast.SetActive(true);
                break;
            case HelpType.Speed:               
                Speed.SetActive(true);
                break;
            default:
                break;
        }
    }
}

public enum HelpType
{
    Enable,
    Disable,
    Kill,
    Activate,
    FastTypes,
    Speed,
}
