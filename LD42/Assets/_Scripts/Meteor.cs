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
    public GameObject KIll;

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
        transform.localPosition = Vector3.zero;
    }

    public void Reset()
    {
        _onMove = true;
        Core.SetActive(true);
        _rigidbody.useGravity = true;
        _rigidbody.velocity = Vector3.zero;
        SubParticle.SetActive(false);
        KIll.SetActive(true);
    }

    private void Disable()
    {
        KIll.SetActive(false);
    }
}
