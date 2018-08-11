using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour
{
    public Transform LabelPlace;

    public Color EnableColor = Color.white;
    public Color DestroyColor = Color.red;
    public Color DisableColor = Color.yellow;

    private GameObject _label;
    private Animator _anim;
    private Text _text;

    public void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _label = Instantiate(Resources.Load("Label"), transform.position + LabelPlace.transform.localPosition, Quaternion.identity) as GameObject;
        _label.transform.SetParent(transform);
        _text = _label.GetComponentInChildren<Text>();
        _text.text = GetComponent<ManagedGameObject>().ManagedName;
        GetComponentInParent<ManagedGameObject>().Label = this;
    }

    public void ShowLabel()
    {
        _anim.SetBool("Show",true);
    }

    public void HideLabel()
    {
        _anim.SetBool("Show", false);
    }

    public void Destroyed()
    {
        _anim.SetInteger("State",0);
        LerpColor(DestroyColor);
    }

    public void Disabled()
    {
        _anim.SetInteger("State", 1);
        LerpColor(DisableColor);
    }

    public void Enabled()
    {
        _anim.SetInteger("State", 2);
        LerpColor(EnableColor);
    }

    public void Activate()
    {
        _anim.SetTrigger("Activate");
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
        float TotalTime = 1.5f;
        Color currentColor = _text.color;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            _text.color = Color.Lerp(currentColor, targetColor, (ElapsedTime / TotalTime));
            yield return null;
        }
    }
}
