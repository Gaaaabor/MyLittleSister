using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public float Speed;
    public bool Move;
    // Update is called once per frame
    void Update()
    {
        if (Move)
            transform.position = Vector3.MoveTowards(transform.position, PlayerController.Instance.transform.position, Speed);
    }

    public void SetMove(bool v)
    {
        Move = v;
    }
}
