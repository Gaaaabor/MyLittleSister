using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed;

    private PlayerState _currentPlayerState;
    private Rigidbody _rigidbody;

    private void Update()
    {
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
        throw new NotImplementedException();
    }
}
public enum PlayerState   
{
    Idle,
    Walking,
    Fight,
    Talking,
}