using System;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : SingletonBase<BuffManager>
{
    public GameObject TimeBuffUi;
    public Text TimeBuffText;
    public float TimeBuffDuration;
    public bool TimeBuffIsActive;
    public float TimeBuffScale;

    public GameObject CaseSensitivenessBuffUi;
    public Text CaseSensitivenessBuffText;
    public float CaseSensitivenessBuffDuration;
    private bool _locked;

    internal void LockTime()
    {
        _locked = false;
    }

    public bool CaseSensitivenessBuffIsActive;

    public override void Awake()
    {
        TimeBuffUi.gameObject.SetActive(false);
        CaseSensitivenessBuffUi.gameObject.SetActive(false);
        SetTimeScale(1, true);
    }

    internal void UnlockTime()
    {
        _locked = true;
    }

    private void Update()
    {
        UpdateTimeBuff();
        UpdateCaseSensitivenessBuff();
    }

    private void UpdateCaseSensitivenessBuff()
    {
        if (!CaseSensitivenessBuffIsActive)
        {
            CaseSensitivenessBuffUi.gameObject.SetActive(false);
            return;
        }
        else
        {
            CaseSensitivenessBuffUi.gameObject.SetActive(true);
        }
     
        if (0 < CaseSensitivenessBuffDuration)
        {
            CommandHandler.Instance.IsCaseSensitive = true;
            CaseSensitivenessBuffDuration -= Time.deltaTime;
        }
        else
        {
            CaseSensitivenessBuffIsActive = false;
            CommandHandler.Instance.IsCaseSensitive = false;
            CaseSensitivenessBuffDuration = 0;
            CaseSensitivenessBuffUi.gameObject.SetActive(false);
        }

        CaseSensitivenessBuffText.text = CaseSensitivenessBuffDuration.ToString("N2");

    }

    public void UpdateTimeBuff()
    {
        if (!TimeBuffIsActive || TimeBuffScale == 1)
        {
            return;
        }

        if (0 < TimeBuffDuration)
        {
            TimeBuffDuration -= (1 - Time.timeScale) * Time.unscaledDeltaTime;
        }
        else
        {
            TimeBuffDuration = 0;
            SetTimeScale(1, true);
        }

        TimeBuffText.text = TimeBuffDuration.ToString("N2");
    }

    public void SetTimeScale(float scale, bool dontEnable = false)
    {
        if (_locked) return;
        if (!dontEnable)
        {
            TimeBuffUi.gameObject.SetActive(true);
        }

        TimeBuffIsActive = true;
        TimeBuffScale = scale;

        if (TimeBuffScale >= 1)
        {
            TimeBuffScale = 1;
            TimeBuffIsActive = false;
        }

        if (TimeBuffScale <= 0)
        {
            TimeBuffScale = 0;
        }


        DoScale();
    }

    private void DoScale()
    {
        Time.timeScale = TimeBuffScale;
    }

    [ContextMenu("TestCaseSensitiveness")]
    public void CaseSensitiveness()
    {
        CaseSensitivenessBuffIsActive = true;
    }

    //unscaled time-al menjen a dialoggal is eventsystem
}
