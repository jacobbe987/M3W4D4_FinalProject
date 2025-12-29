using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : Weapon
{
    private PlayerController _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private GameObject PlayerShoot()
    {
        GameObject _playerToShoot = null;
        float _rangeDistance = _rangeOfFire;

        float _distance = Vector2.Distance(transform.position, _player.transform.position);
            if (_distance < _rangeDistance)
            {
                _rangeDistance = _distance;
                _playerToShoot = _player.gameObject;
            }

        return _playerToShoot;
    }
    protected override void Shoot()
    {
        GameObject _playerPos = PlayerShoot();
        if (_playerPos != null)
        {
            Vector2 _direction = (_playerPos.transform.position - transform.position).normalized;
            Bullet _bullet = Instantiate(_prefabBullet, transform);
            _bullet.transform.position = (Vector2)transform.parent.position + _direction * 0.5f;
            _bullet.BulletShooted(_direction);
        }
    }
}
