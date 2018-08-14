using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Label))]
public class ManagedGameObject : MonoBehaviour
{
    [HideInInspector]
    public bool _isDestroyed;

    private ManagedGameObjectMemento _memento = new ManagedGameObjectMemento();

    public string ManagedName;
    public ObjectState CurrentState;
    public bool StartEnabled;
    public GameObject TargetObject;

    [Header("Enable")]
    public bool CanEnable = true;
    public UnityEvent EnableEvent;
    private bool _StartEnable;
    [Header("Disable")]
    public bool CanDisable = true;
    public UnityEvent DisableEvent;
    private bool _StartDisable;
    [Header("Destroy")]
    public bool CanDestroy = true;
    public UnityEvent DestroyEvent;
    private bool _StartDestroy;
    [Header("Active")]
    public bool CanActivate = true;
    public UnityEvent ActivateEvent;
    private bool _Startactivate;
    [Header("Reset")]
    public UnityEvent ResetEvent;

    [HideInInspector]
    public Label Label;
    private bool _initialized;

    private void Awake()
    {
        _Startactivate = CanActivate;
        _StartDestroy = CanDestroy;
        _StartDisable = CanDisable;
        _StartEnable = CanDisable;

        Initilazie();
    }

    private void OnEnable()
    {
        if (!_initialized)
        {
            Initilazie();
        }
    }

    private void Initilazie()
    {
        Label = GetComponent<Label>();
        Label.Initialize();

        if (StartEnabled)
        {

            if (CanEnable)
            {
                CurrentState = ObjectState.Enabeled;
                Label.Enabled();
                if (TargetObject != null)
                    TargetObject.SetActive(true);
            }
        }
        else
        {
            if (CanDisable && !_isDestroyed)
            {
                CurrentState = ObjectState.Disabled;
                Label.Disabled();
                if (TargetObject != null)
                    TargetObject.SetActive(false);
            }
        }

        _memento.Save(this);
        GameObjectManager.Instance.RegisterObject(this);

        _initialized = true;
    }

    public void DisableComandable()
    {
        CanEnable = false;
        CanActivate = false;
        CanDestroy = true;
        CanDisable = false;
        Label.gameObject.SetActive(false);
    }

    public void EnableCommandable()
    {
        CanEnable = _StartEnable;
        CanActivate = _Startactivate;
        CanDestroy = _StartDestroy;
        CanDisable = _StartDisable;
        Label.gameObject.SetActive(true);
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
            CurrentState = ObjectState.Destroyed;
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
            CurrentState = ObjectState.Disabled;
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
            CurrentState = ObjectState.Enabeled;
            Label.Enabled();
            if (TargetObject != null)
                TargetObject.SetActive(true);
            EnableEvent.Invoke();
        }
    }

    public void Restore()
    {
        EnableCommandable();
        if (StartEnabled)
        {
            if (CanEnable)
            {
                CurrentState = ObjectState.Enabeled;
                Label.Enabled();
                if (TargetObject != null)
                    TargetObject.SetActive(true);
            }
        }
        else
        {
            if (CanDisable && !_isDestroyed)
            {
                CurrentState = ObjectState.Disabled;
                Label.Disabled();
                if (TargetObject != null)
                    TargetObject.SetActive(false);
            }
        }
        Label.CheackVisiblety();
        ResetEvent.Invoke();
        _memento.Restore(this);
    }

    public enum ObjectState
    {
        Default,
        Enabeled,
        Disabled,
        Destroyed,
    }
}
