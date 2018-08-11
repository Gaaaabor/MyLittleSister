using Assets._Scripts.Manager;
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

    public GameObject ObjectOverride;

    [HideInInspector]
    public Label Label;

    private void Start()
    {
        if (ObjectOverride == null)
        {
            ObjectOverride = transform.GetChild(0).gameObject;
        }

        if (StartEnabled)
        {
            SetEnabledState();
        }
        else
        {
            SetDisabledState();
        }

        _memento.Save(this);
        GameObjectManager.Instance.RegisterObject(this);
    }

    public void SetActivatedState()
    {
        if (CanActivate && ObjectOverride.activeInHierarchy && !_isDestroyed)
        {
            ActivateEvent.Invoke();
        }
    }

    public void SetDestroyedState()
    {
        if (CanDestroy)
        {
            Label.Destroyed();
            _isDestroyed = true;
            ObjectOverride.SetActive(false);
            DestroyEvent.Invoke();
        }
    }

    public void SetDisabledState()
    {
        if (CanDisable && !_isDestroyed)
        {
            Label.Disabled();
            ObjectOverride.SetActive(false);
            DisableEvent.Invoke();
        }
    }

    public void SetEnabledState()
    {
        if (CanEnable)
        {
            Label.Enabled();
            ObjectOverride.SetActive(true);
            EnableEvent.Invoke();
        }
    }

    public void Restore()
    {
        _memento.Restore(this);
    }
}
