using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Creature
{
    [SerializeField] private float _speed;
    [SerializeField] public GameObject _shieldPrefab;
    private float _horizontal, _vertical;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private PlayerAnimation _playerAnimation;
    private bool _isDead = false;

    public Vector2 Direction { get => _direction; }

    protected override void Awake()
    {
        base.Awake();
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimation =GetComponent<PlayerAnimation>();
    }

    private void FixedUpdate()
    {
        if (_isDead) return;
        Movement();
        _playerAnimation.IsWalking();
    }

    private void Movement()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _direction = new Vector2(_horizontal, _vertical).normalized;
        
        _rb.MovePosition(_rb.position + _direction * (Time.fixedDeltaTime * _speed));
        

    }

    public void Shield()
    {
        if (_lifeController.Shield != 0)
        {
            Instantiate(_shieldPrefab, transform);
        }
    }

    public override void Dead()
    {
        base.Dead();
        _playerAnimation.IsDead();
        _isDead = true;
        
        
    }

    
}
