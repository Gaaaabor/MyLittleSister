using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour
{
    public Transform LabelPlace;

    public Color EnableColor = Color.white;
    public Color DestroyColor = Color.red;
    public Color DisableColor = Color.yellow;
    public Color ActivateColor = Color.cyan;

    private GameObject _label;
    private Animator _anim;
    private Text _text;

    public void Awake()
    {
        _label = Instantiate(Resources.Load("Label"), transform.position + LabelPlace.transform.localPosition, Quaternion.identity) as GameObject;
        _label.transform.SetParent(transform);
        _anim = _label.GetComponentInChildren<Animator>();
        _text = _label.GetComponentInChildren<Text>();
        _text.text = GetComponent<ManagedGameObject>().ManagedName;
        GetComponentInParent<ManagedGameObject>().Label = this;
        LabelManager.Instance.RegisterLabel(this);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        if (LabelManager.Instance.LabelsVisible)
        {
            ShowLabel();
        }
        else
        {
            HideLabel();
        }
    }

    public void ShowLabel()
    {
        Debug.Log("ShowLabel");
        _anim.SetBool("Show", true);
    }

    public void HideLabel()
    {
        _anim.SetBool("Show", false);
    }

    public void Destroyed()
    {
        _anim.SetInteger("State", 0);
        StopAllCoroutines();
        StartCoroutine(LerpColor(DestroyColor));
    }

    public void Disabled()
    {
        _anim.SetInteger("State", 1);
        StopAllCoroutines();
        StartCoroutine(LerpColor(DisableColor));
    }

    public void Enabled()
    {
        _anim.SetInteger("State", 2);
        StopAllCoroutines();
        StartCoroutine(LerpColor(EnableColor));
    }

    public void Activate()
    {
        _anim.SetTrigger("Activate");
        StopAllCoroutines();
        StartCoroutine(LerpColorAndBack(ActivateColor));
    }

    void Reset()
    {
        if (LabelPlace == null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).name == "LabelPlace")
                {
                    LabelPlace = transform.GetChild(i);
                    return;
                }
            }
            LabelPlace = new GameObject("LabelPlace").transform;
            LabelPlace.transform.SetParent(transform);
            LabelPlace.transform.localPosition = Vector3.zero;
        }
    }

    public IEnumerator LerpColor(Color targetColor)
    {
        float ElapsedTime = 0.0f;
        Color currentColor = _text.color;
        while (ElapsedTime < 1.5f)
        {
            ElapsedTime += Time.deltaTime;
            _text.color = Color.Lerp(currentColor, targetColor, (ElapsedTime / 1.5f));
            yield return null;
        }
    }

    private IEnumerator LerpColorAndBack(Color targetColor)
    {
        float ElapsedTime = 0.0f;
        Color currentColor = _text.color;
        while (ElapsedTime < 0.5f)
        {
            ElapsedTime += Time.deltaTime;
            _text.color = Color.Lerp(currentColor, targetColor, (ElapsedTime / 0.5f));
            yield return null;
        }
        ElapsedTime = 0;
        while (ElapsedTime < 1f)
        {
            ElapsedTime += Time.deltaTime;
            yield return null;
        }
        ElapsedTime = 0;
        while (ElapsedTime < 0.5f)
        {
            ElapsedTime += Time.deltaTime;
            _text.color = Color.Lerp(targetColor, currentColor, (ElapsedTime / 0.5f));
            yield return null;
        }
    }

}
