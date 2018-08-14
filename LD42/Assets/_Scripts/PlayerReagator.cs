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
    private List<GameObject> _insatntiated = new List<GameObject>();
    private List<Vector3> _startPoses = new List<Vector3>();
    public bool ResetPose = true;

    private void Awake()
    {
        if (Prefab != null)
            Prefab.SetActive(false);

        if (ResetPose)
            foreach (var item in ActiveStartOjects)
            {
                _startPoses.Add(item.transform.position);
                item.SetActive(false);
            }
    }

    public void Spawn()
    {
        GameObject go = Instantiate(Prefab, transform.position, Quaternion.identity);
        go.gameObject.SetActive(true);
        _insatntiated.Add(go);
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

    public void Reset()
    {
        CancelInvoke();
        foreach (var item in _insatntiated)
        {
            Destroy(item);
        }
        _insatntiated.Clear();
        if (ResetPose)
            for (int i = 0; i < ActiveStartOjects.Count; i++)
            {
                ActiveStartOjects[i].transform.position = _startPoses[i];

            }

        foreach (var item in ActiveStartOjects)
        {
            item.SetActive(false);

            var move = item.GetComponent<MoveToPlayer>();
            if (move != null)
            {
                move.Reset();
            }
        }
    }

    private void OnEnable()
    {
        Reset();
    }
}
