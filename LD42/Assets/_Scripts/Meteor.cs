using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Vector3 Direction;
    private Rigidbody _rigidbody;

    public GameObject Core;
    public float ExplodeTime;
    public GameObject SubParticle;
    public bool _onMove;

    private void OnEnable()
    {
        _onMove = true;
        Core.SetActive(true);
        _rigidbody.useGravity = true;
        _rigidbody.velocity = Vector3.zero;
        SubParticle.SetActive(false);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_onMove)
            _rigidbody.velocity = new Vector3(Direction.x, _rigidbody.velocity.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _onMove = false;
        SubParticle.SetActive(true);
        Core.SetActive(false);
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
        Invoke("Disable", ExplodeTime);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
