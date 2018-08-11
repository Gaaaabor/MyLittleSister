using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public List<ManagedGameObject> ManagedObjects;

    //public static GameObjectManager Instance
    //{
    //    get
    //    {
    //        return null;
    //    }
    //}

    public void RegisterObject(ManagedGameObject managedGameObject)
    {
        ManagedObjects.Add(managedGameObject);
    }
}
