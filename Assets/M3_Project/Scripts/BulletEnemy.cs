using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

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
}
