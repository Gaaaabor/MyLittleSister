using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : SingletonBase<BuffManager>
{
    private float _myTime;

    public float MyTime
    {
        get
        {
            return _myTime;
        }
        set
        {
            _myTime = value;
            TimeBuffText.text = _myTime.ToString("N1");
        }
    }

    public GameObject TimeBuffUi;
    public Text TimeBuffText;

    public GameObject CaseSensitivenessBuffUi;
    public Text CaseSensitivenessBuffText;

    private List<BuffBase> _Buffs = new List<BuffBase>();

    private void Awake()
    {
        TimeBuffUi.gameObject.SetActive(false);
        CaseSensitivenessBuffUi.gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateBuffs();
    }

    private void UpdateBuffs()
    {
        if (_Buffs == null || !_Buffs.Any())
        {
            return;
        }

        foreach (var buff in _Buffs.ToList())
        {
            if (buff.IsExpired)
            {
                HideBuffText(buff);
                _Buffs.Remove(buff);
                continue;
            }

            buff.OnStart();
            buff.Apply();
            buff.OnEnd();

            UpdateBuffText(buff);
        }
    }

    public void ChangeTime(float scale)
    {
        AddBuff(new TimeBuff(scale, 10f));
    }

    [ContextMenu("TestTime")]
    public void AddTime(float time)
    {
        AddBuff(new TimeBuff(0.1f, 10f));
    }

    [ContextMenu("TestCaseSensitiveness")]
    public void CaseSensitiveness()
    {
        AddBuff(new CaseSensitivenessBuff(10f));
    }

    private void AddBuff(BuffBase buff)
    {
        if (_Buffs != null && _Buffs.All(x => !x.Name.Equals(buff.Name, StringComparison.OrdinalIgnoreCase)))
        {
            _Buffs.Add(buff);
        }
    }

    private void UpdateBuffText(BuffBase buff)
    {
        var duration = buff.Duration.ToString("N2");

        switch (buff.Name)
        {
            case "TimeBuff":
                TimeBuffText.text = duration;
                TimeBuffUi.gameObject.SetActive(true);
                break;
            case "CaseSensitivenessBuff":
                CaseSensitivenessBuffText.text = duration;
                CaseSensitivenessBuffUi.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void HideBuffText(BuffBase buff)
    {
        switch (buff.Name)
        {
            case "TimeBuff":
                TimeBuffText.text = string.Empty;
                TimeBuffUi.gameObject.SetActive(false);
                break;
            case "CaseSensitivenessBuff":
                CaseSensitivenessBuffText.text = string.Empty;
                CaseSensitivenessBuffUi.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
