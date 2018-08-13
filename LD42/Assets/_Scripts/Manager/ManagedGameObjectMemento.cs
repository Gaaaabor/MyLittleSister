using System;
using UnityEngine;

[Serializable]
public class ManagedGameObjectMemento
{
    private bool _isActive;
    private Vector3 _position;
    private Quaternion _rotation;
    private bool _isDestroyed;

    public void Save(ManagedGameObject item)
    {
     //   _isActive = item.gameObject.activeSelf;
        _position = item.transform.localPosition;
        _rotation = item.transform.localRotation;

        if (item.CanDestroy)
        {
            _isDestroyed = item._isDestroyed;
        }
    }

    public void Restore(ManagedGameObject item)
    {
      //  item.gameObject.SetActive(_isActive);
        item.transform.localPosition = _position;
        item.transform.localRotation = _rotation;

        if (item.CanDestroy)
        {
            item._isDestroyed = _isDestroyed;
        }
    }
}