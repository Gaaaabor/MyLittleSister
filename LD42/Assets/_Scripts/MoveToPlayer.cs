using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public float Speed;
    public bool Move;
    // Update is called once per frame

    private Vector3 _startPos;
    private bool _startMove;

    private void Awake()
    {
        _startMove = Move;
        _startPos = transform.position;
    }

    void Update()
    {
        if (Move)
            transform.position = Vector3.MoveTowards(transform.position, PlayerController.Instance.transform.position, Speed *Time.deltaTime);
    }

    public void SetMove(bool v)
    {
        Move = v;
    }

    public void Reset()
    {
        Move = _startMove;
        transform.position = _startPos;
    }
}
