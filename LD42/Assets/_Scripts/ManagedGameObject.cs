using Assets._Scripts.Manager;
using UnityEngine;

//[RequireComponent(typeof(Label))]
public class ManagedGameObject : MonoBehaviour
{
    [HideInInspector]
    public bool _isDestroyed;

    private ManagedGameObjectMemento _memento = new ManagedGameObjectMemento();

    public string ManagedName;
    public bool CanDestroy = true;
    public bool CanEnable = true;
    public bool CanDisable = true;

    internal void SetActivatedState()
    {
        //TODO
    }

    internal void SetDestroyedState()
    {
        if (CanDestroy)
        {
            _isDestroyed = true;
            gameObject.SetActive(false);
        }
    }

    internal void SetDisabledState()
    {
        if (CanDisable)
        {
            gameObject.SetActive(false);
        }
    }

    internal void SetEnabledState()
    {
        if (CanEnable)
        {
            gameObject.SetActive(true);
        }
    }

    internal void Restore()
    {
        _memento.Restore(this);
    }

    private void Awake()
    {
        _memento.Save(this);
        GameObjectManager.Instance.RegisterObject(this);
    }
}
