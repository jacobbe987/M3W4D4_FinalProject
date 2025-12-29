using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet _prefabBullet;
    [SerializeField] protected float _rateOfFire;
    [SerializeField] protected float _rangeOfFire;
    protected float _lastShot;

    protected abstract void Shoot();

    private bool CanShoot()
    {
        return Time.time-_lastShot > _rateOfFire;
    }

    private void TryShoot()
    {
        if (CanShoot())
        {
            _lastShot = Time.time;
            Shoot();
        }
    }

    private void Update()
    {
        TryShoot();
    }

    
}
