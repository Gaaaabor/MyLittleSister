using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerReagator : MonoBehaviour
{
    public List<GameObject> ActiveStartOjects;
    public GameObject Prefab;
    public float TimeInterval;
    public UnityEvent Event;

    private void Awake()
    {
        if (Prefab != null)
            Prefab.SetActive(false);
        foreach (var item in ActiveStartOjects)
        {
            item.SetActive(false);
        }
    }

    public void Spawn()
    {
        Instantiate(Prefab).gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var item in ActiveStartOjects)
            {
                item.SetActive(true);
            }
            Event.Invoke();
            if (Prefab != null)
                StartSpawn();
        }
    }
    [ContextMenu("StartSpawn")]
    private void StartSpawn()
    {
        InvokeRepeating("Spawn", TimeInterval, TimeInterval);
    }
}
