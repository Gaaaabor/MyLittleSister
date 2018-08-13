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
    private bool _initialized;

    private void Awake()
    {
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
