using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMouseAim : Weapon
{
    protected override void Shoot()
    {
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _mousePos.z = 0;

        Vector3 direction = (_mousePos - transform.position).normalized;

        Bullet _bulletInstantiated = Instantiate(_prefabBullet, transform);

        _bulletInstantiated.transform.position = transform.position + direction * 0.5f;

        _bulletInstantiated.BulletShooted(direction);

        
    }
}