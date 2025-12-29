using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Creature
{
    [SerializeField] protected Weapon _enemyWeapon;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _dmg;
    [SerializeField] protected Pickups[] _objToDrop;

    protected EnemyManager _enemyManager;

    protected override void Awake()
    {
        base.Awake();
        _enemyManager = FindObjectOfType<EnemyManager>();
        _enemyManager.AddEnemyToList(this);
        if (_enemyWeapon != null)
        {
            Instantiate(_enemyWeapon, transform);
        }
    }

    
    protected virtual void EnemyAction()
    {
        
    }

    private void DropRate()
    {
        int _randomDropRate = Random.Range(0, 51);

        if(_randomDropRate <= 10)
        {
            Instantiate(_objToDrop[0], transform.position, Quaternion.identity);
        }
        else if (_randomDropRate <= 20 && _randomDropRate > 10)
        {
            Instantiate(_objToDrop[1], transform.position, Quaternion.identity);
        }
        else if (_randomDropRate <= 30 && _randomDropRate > 20)
        {
            Instantiate(_objToDrop[2], transform.position, Quaternion.identity);
        }
        else if (_randomDropRate <= 40 && _randomDropRate > 30)
        {
            Instantiate(_objToDrop[3], transform.position, Quaternion.identity);
        }
        else if (_randomDropRate <= 50 && _randomDropRate > 40)
        {
            Instantiate(_objToDrop[4], transform.position, Quaternion.identity);
        }
        else if (_randomDropRate <= 60 && _randomDropRate > 50)
        {
            Instantiate(_objToDrop[5], transform.position, Quaternion.identity);
        }
        else if (_randomDropRate <= 70 && _randomDropRate > 60)
        {
            Instantiate(_objToDrop[6], transform.position, Quaternion.identity);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        var _lifeController = collision.collider.GetComponent<LifeController>();

        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {

            player.Hitted(_dmg);
            if (_lifeController.Hp <= 0)
            {
                player.Dead();
            }
        }
    }

    private void FixedUpdate()
    {
        EnemyAction();
    }

    public override void Dead()
    {
        base.Dead();
        _enemyManager.RemoveEnemyFromList(this);
        DropRate();
    }


}
