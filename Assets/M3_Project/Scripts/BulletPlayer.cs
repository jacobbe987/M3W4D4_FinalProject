using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        var _lifeController = collision.collider.GetComponent<LifeController>();

        if (collision.collider.TryGetComponent<EnemyController>(out var enemy))
        {

            enemy.Hitted(_dmg);
            if (_lifeController.Hp <= 0)
            {
                enemy.Dead();
            }
        }
    }
}
