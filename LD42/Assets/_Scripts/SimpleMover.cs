using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    public float Speed;
    public bool Move;
    public Vector3 Direction;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Move)
            _rigidbody.velocity = new Vector3(Direction.x, _rigidbody.velocity.y, 0);
    }
}
