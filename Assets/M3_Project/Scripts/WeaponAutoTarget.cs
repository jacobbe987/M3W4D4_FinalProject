using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAutoTarget : Weapon
{
    private EnemyManager _enemyManager;

    private void Awake()
    {
        _enemyManager = FindObjectOfType<EnemyManager>();
    }

    private GameObject EnemyToShoot() 
    {
        GameObject _enemyToShoot = null;
        float _rangeDistance = _rangeOfFire;

        foreach (var enemy in _enemyManager.EnemyControllers)
        {
            float _distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (_distance < _rangeDistance)
                {
                    _rangeDistance = _distance;
                    _enemyToShoot = enemy.gameObject;
                }
        }

        return _enemyToShoot;
    }
    protected override void Shoot()
    {
        GameObject _closestEnemy = EnemyToShoot();
        if (_closestEnemy != null)
        {
            Vector2 _direction= (_closestEnemy.transform.position - transform.position).normalized;
            Bullet _bullet = Instantiate(_prefabBullet, transform);
            _bullet.transform.position = (Vector2)transform.parent.position + _direction * 0.5f;
            _bullet.BulletShooted(_direction);
        }
    }
}
