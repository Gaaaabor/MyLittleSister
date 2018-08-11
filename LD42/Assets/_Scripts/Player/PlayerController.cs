using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : SingletonBase<PlayerController>
{
    public float PlayerSpeed;
    public Vector3 MoveDirection;
    public float Gravity;


    public PlayerState _currentPlayerState;
    private Rigidbody _rigidbody;
    private CharacterController _charController;
    private Vector3 _moveDirection;

    private CheckPoint _lastCheckPoint;
    private float _Z;
    public override void Awake()
    {
        base.Awake();
        _Z = transform.position.z;
        _rigidbody = GetComponent<Rigidbody>();
        _charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveDirection = MoveDirection;
        _moveDirection.y -= Gravity * Time.deltaTime;

        switch (_currentPlayerState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Walking:
                WalkForward();
                break;
            case PlayerState.Fight:
                break;
            case PlayerState.Talking:
                break;
            default:
                break;
        }
    }

    private void WalkForward()
    {
        _charController.Move(_moveDirection * PlayerSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, _Z);
    }

    public void SetCheckPoint(CheckPoint checkPoint)
    {
        _lastCheckPoint = checkPoint;
    }

    [ContextMenu("Die")]
    public void Die()
    {
        ResetToCheckPoint();
    }

    public void IdlePlayer()
    {
        _currentPlayerState = PlayerState.Idle;
    }

    public void WalkPlayer()
    {
        _currentPlayerState = PlayerState.Walking;
    }

    public void FightPlayer()
    {
        _currentPlayerState = PlayerState.Fight;
    }

    public void TalkPlay()
    {
        _currentPlayerState = PlayerState.Talking;
    }

    private void ResetToCheckPoint()
    {
        transform.position = _lastCheckPoint.transform.position;
        _lastCheckPoint.ResetCheckPoint();
    }
}

public enum PlayerState
{
    Idle,
    Walking,
    Fight,
    Talking,
}