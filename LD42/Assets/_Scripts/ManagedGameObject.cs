using Assets._Scripts.Manager;
using UnityEngine;

public class ManagedGameObject : MonoBehaviour
{
    private ManagedGameObjectMemento _memento = new ManagedGameObjectMemento();

    public string ManagedName;
    public bool CanDestroy;
    public bool CanDisable;
    public bool IsDestroyed;    

    internal void SetDestroyedState()
    {
        if (CanDestroy)
        {
            IsDestroyed = true;
            gameObject.SetActive(false);
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
