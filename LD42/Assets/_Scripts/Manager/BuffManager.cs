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
    public bool CaseSensitivenessBuffIsActive;

    private void Awake()
    {
        TimeBuffUi.gameObject.SetActive(false);
        CaseSensitivenessBuffUi.gameObject.SetActive(false);
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
            return;
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
        }

        CaseSensitivenessBuffText.text = CaseSensitivenessBuffDuration.ToString("N2");
        CaseSensitivenessBuffUi.gameObject.SetActive(true);
    }

    private void UpdateTimeBuff()
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
            TimeBuffIsActive = false;
            TimeBuffDuration = 0;
            TimeBuffScale = 1;
            Time.timeScale = 1;            
        }

        TimeBuffText.text = TimeBuffDuration.ToString("N2");
        TimeBuffUi.gameObject.SetActive(true);
    }

    public void SetTimeScale(float scale)
    {
        TimeBuffScale = Mathf.Min(Mathf.Abs(scale), 1);

        if (TimeBuffScale == 1)
        {
            TimeBuffIsActive = false;
            return;
        }

        if (0 < TimeBuffDuration)
        {
            TimeBuffIsActive = true;
        }
    }

    [ContextMenu("TestCaseSensitiveness")]
    public void CaseSensitiveness()
    {
        CaseSensitivenessBuffIsActive = true;
    }

    //unscaled time-al menjen a dialoggal is eventsystem
}
