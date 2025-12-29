using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponShotgun : Weapon
{
    private Vector2[] _dirArr;
    protected override void Shoot()
    {
        Vector2 LxUpDir = new Vector2(-1, 1).normalized;
        Vector2 RxUpDir = new Vector2(1, 1).normalized;
        Vector2 LxDownDir = new Vector2(-1, -1).normalized;
        Vector2 RxDownDir = new Vector2(1, -1).normalized;
        Vector2 UpDir = Vector2.up;
        Vector2 DownDir = Vector2.down;
        Vector2 LxDir = Vector2.left;
        Vector2 RxDir = Vector2.right;

        _dirArr = new Vector2[]
        {
            LxUpDir,
            RxUpDir,
            LxDownDir,
            RxDownDir,
            UpDir,
            DownDir,
            LxDir,
            RxDir
        };

        foreach (var dir in _dirArr)
        {
            Bullet _bullet = Instantiate(_prefabBullet, transform);
            _bullet.transform.position = (Vector2)transform.parent.position + dir * 1f;
            _bullet.BulletShooted(dir);
        }
    }
}
