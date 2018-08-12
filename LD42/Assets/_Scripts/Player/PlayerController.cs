﻿using System;
using UnityEngine;

public class PlayerController : SingletonBase<PlayerController>
{
    public float WalkSpeed;
    public float RunSpeed;

    public Vector3 MoveDirection;
    public float Gravity;

    public PlayerState _currentPlayerState;
    private Rigidbody _rigidbody;

    public Animator Anim;

    internal void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private CharacterController _charController;
    private Vector3 _moveDirection;

    private CheckPoint _lastCheckPoint;
    private float _Z;

    public GameObject Torch;
    public bool TorchInhand;
    public GameObject Sword;
    public bool SwordInHand;
    public GameObject Princess;
    public bool PrincessInHand;
    private PlayerState _lastState;

    public override void Awake()
    {
        base.Awake();
        _Z = transform.position.z;
        _rigidbody = GetComponent<Rigidbody>();
        _charController = GetComponent<CharacterController>();
        SetInventory();
    }

    private void SetInventory()
    {
        if (PrincessInHand)
        {
            Torch.SetActive(false);
            Sword.SetActive(false);

            Princess.SetActive(PrincessInHand);
        }
        else
        {
            Torch.SetActive(TorchInhand);
            Sword.SetActive(SwordInHand);
            Princess.SetActive(false);
        }
    }

    public void SetTorch(bool v)
    {
        TorchInhand = v;
        SetInventory();
    }

    public void SetPrincess(bool v)
    {
        PrincessInHand = v;
        SetInventory();
    }

    public void SetSword(bool v)
    {
        SwordInHand = v;
        SetInventory();
    }

    private void Update()
    {
        _moveDirection = Vector3.zero;

        switch (_currentPlayerState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Walking:
                WalkForward();
                break;
            case PlayerState.Run:
                RunForward();
                break;
            default:
                break;
        }

        _moveDirection.y -= Gravity * Time.deltaTime;
        _charController.Move(_moveDirection);
        transform.position = new Vector3(transform.position.x, transform.position.y, _Z);

        UpdateAnim();
    }

    private void UpdateAnim()
    {
        Anim.SetFloat("Speed", _charController.velocity.x);
    }

    private void WalkForward()
    {
        _moveDirection += MoveDirection * WalkSpeed * Time.deltaTime;
    }

    private void RunForward()
    {
        _moveDirection += MoveDirection * RunSpeed * Time.deltaTime;
    }

    public void SetCheckPoint(CheckPoint checkPoint)
    {
        _lastCheckPoint = checkPoint;
    }

    [ContextMenu("Die")]
    public void Die()
    {
        if (_currentPlayerState == PlayerState.Dead) return;
        _rigidbody.isKinematic = true;
        SetPlayerState(PlayerState.Dead);
        Debug.Log("InvokeREset");
        Invoke("ResetToCheckPoint", 1.5f);
    }

    public void SetPlayerState(PlayerState playerState)
    {
        Debug.Log("Try " + playerState);
        if (_currentPlayerState == playerState) return;

        _lastState = _currentPlayerState;
        _currentPlayerState = playerState;

        switch (playerState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Walking:
                break;
            case PlayerState.Run:
                break;
            case PlayerState.Dead:
                Anim.SetTrigger("Die");
                break;
            default:
                break;
        }
        Debug.Log("Done " + playerState);
    }

    private void ResetToCheckPoint()
    {
        if (_lastCheckPoint != null)
        {
            transform.position = _lastCheckPoint.transform.position;
            _lastCheckPoint.ResetCheckPoint();
        }

        Invoke("ResetDone", 0.5f);
        Debug.Log("Reset1");
    }

    private void ResetDone()
    {
        _rigidbody.isKinematic = false;
        Anim.SetTrigger("Respawn");
        SetPlayerState(_lastState);
        Debug.Log("Reset1");
    }
}

public enum PlayerState
{
    Idle,
    Walking,
    Run,
    Dead
}