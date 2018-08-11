using Assets._Scripts.Manager;
using UnityEngine;

[RequireComponent(typeof(Label))]
public class ManagedGameObject : MonoBehaviour
{
    [HideInInspector]
    public bool _isDestroyed;

    private ManagedGameObjectMemento _memento = new ManagedGameObjectMemento();

    public string ManagedName;

    public bool StartEnabled;

    public bool CanDestroy = true;
    public bool CanEnable = true;
    public bool CanDisable = true;

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
        if (CanEnable && !_isDestroyed)
        {
            ObjectOverride.SetActive(true);
        }
    }

    public void SetDestroyedState()
    {
        if (CanDestroy)
        {
            Label.Destroyed();
            _isDestroyed = true;
            ObjectOverride.SetActive(false);
        }
    }

    public void SetDisabledState()
    {
        if (CanDisable && !_isDestroyed)
        {
            Label.Disabled();
            ObjectOverride.SetActive(false);
        }
    }

    public void SetEnabledState()
    {
        if (CanEnable)
        {
            Label.Enabled();
            ObjectOverride.SetActive(true);
        }
    }

    public void Restore()
    {
        _memento.Restore(this);
    }
}
