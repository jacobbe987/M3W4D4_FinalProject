using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaw : EnemyController
{
    private PlayerController _playerController;
    

    protected override void Awake()
    {
        base.Awake();
        _playerController = FindObjectOfType<PlayerController>();
        
    }
    protected override void EnemyAction()
    {
        Vector2 _enemyPos = transform.position;
        Vector2 _playerPos = _playerController.transform.position;
        Vector2 _direction= _playerPos - _enemyPos;
        _direction.Normalize();

        Vector2 _targetPos = Vector2.MoveTowards(_enemyPos, _playerPos, _speed*Time.deltaTime);
        transform.position = _targetPos;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            base.Dead();
            
        }

    }

}
