using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Label))]
public class ManagedGameObject : MonoBehaviour
{
    [HideInInspector]
    public bool _isDestroyed;

    private ManagedGameObjectMemento _memento = new ManagedGameObjectMemento();

    public string ManagedName;

    public bool StartEnabled;
    public GameObject TargetObject;

    [Header("Enable")]
    public bool CanEnable = true;
    public UnityEvent EnableEvent;

    [Header("Disable")]
    public bool CanDisable = true;
    public UnityEvent DisableEvent;

    [Header("Destroy")]
    public bool CanDestroy = true;
    public UnityEvent DestroyEvent;

    [Header("Active")]
    public bool CanActivate = true;
    public UnityEvent ActivateEvent;

    [Header("Reset")]
    public UnityEvent ResetEvent;

    [HideInInspector]
    public Label Label;

    private void Start()
    {
        if (StartEnabled)
        {
            //Debug.Log("StartEnabled" + gameObject.name);
            SetEnabledState();
        }
        else
        {
            //Debug.Log("StartDisabled" + gameObject.name);
            SetDisabledState();
        }

        _memento.Save(this);
        GameObjectManager.Instance.RegisterObject(this);
    }

    public void DisableComandable()
    {
        CanEnable = false;
        CanActivate = false;
        CanDestroy = true;
        CanDisable = false;
        Label.gameObject.SetActive(false);
    }

    public void SetActivatedState()
    {
        if (CanActivate && !_isDestroyed)
        {
            Label.Activate();
            ActivateEvent.Invoke();
        }
    }

    public void SetDestroyedState()
    {
        if (CanDestroy)
        {
            Label.Destroyed();
            _isDestroyed = true;
            if (TargetObject != null)
                TargetObject.SetActive(false);
            DestroyEvent.Invoke();
        }
    }

    public void SetDisabledState()
    {
        if (CanDisable && !_isDestroyed)
        {
            Label.Disabled();
            if (TargetObject != null)
                TargetObject.SetActive(false);
            DisableEvent.Invoke();
        }
    }

    public void SetEnabledState()
    {
        if (CanEnable)
        {
            Label.Enabled();
            if (TargetObject != null)
                TargetObject.SetActive(true);
            EnableEvent.Invoke();
        }
    }

    public void Restore()
    {
        ResetEvent.Invoke();
        _memento.Restore(this);
    }
}
