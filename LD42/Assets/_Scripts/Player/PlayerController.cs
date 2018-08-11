using System;
using UnityEngine;

public class PlayerController : SingletonBase<PlayerController>
{
    public float PlayerSpeed;
    public Vector3 MoveDirection;
    public float Gravity;

    public float RunSpeed;

    public PlayerState _currentPlayerState;
    private Rigidbody _rigidbody;
    private CharacterController _charController;
    private Vector3 _moveDirection;

    private CheckPoint _lastCheckPoint;
    private float _Z;

    public GameObject Torch;
    public bool TorchInhand;

    public override void Awake()
    {
        base.Awake();
        _Z = transform.position.z;
        _rigidbody = GetComponent<Rigidbody>();
        _charController = GetComponent<CharacterController>();
        if (TorchInhand)
        {
            SetTorch(true);
        }
        else
        {
            SetTorch(false);
        }
    }

    public void SetTorch(bool v)
    {
        Torch.SetActive(v);
        TorchInhand = v;
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
            case PlayerState.Fight:
                break;
            case PlayerState.Talking:
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
    }

    private void WalkForward()
    {
        _moveDirection += MoveDirection * PlayerSpeed * Time.deltaTime;
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

    public void DialogPlay()
    {
        _currentPlayerState = PlayerState.Talking;
    }

    public void SetPlayerState(PlayerState playerState)
    {
        _currentPlayerState = playerState;
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
    Run
}