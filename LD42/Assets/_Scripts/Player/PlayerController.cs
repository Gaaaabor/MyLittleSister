using System;
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
        Torch.SetActive(TorchInhand);
        Sword.SetActive(SwordInHand);
    }

    public void SetTorch(bool v)
    {
        TorchInhand = v;
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
        Anim.SetTrigger("Respawn");
        _lastCheckPoint = checkPoint;
    }

    [ContextMenu("Die")]
    public void Die()
    {
        SetPlayerState(PlayerState.Dead);
        Invoke("ResetToCheckPoint", 1.5f);  
    }

    public void SetPlayerState(PlayerState playerState)
    {
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
    }

    private void ResetToCheckPoint()
    {
        SetPlayerState(PlayerState.Walking);
        if (_lastCheckPoint != null)
        {
            transform.position = _lastCheckPoint.transform.position;
            _lastCheckPoint.ResetCheckPoint();
        }
    }
}

public enum PlayerState
{
    Idle,
    Walking,
    Run,
    Dead
}