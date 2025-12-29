using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpiral : Weapon
{
    private int _index;
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
            UpDir,
            RxUpDir,
            RxDir,
            RxDownDir,
            DownDir,
            LxDownDir,
            LxDir,
            LxUpDir
        };

        if (_index >= _dirArr.Length)
        {
            _index=0;
        }
        Bullet _bullet = Instantiate(_prefabBullet, transform);
        _bullet.transform.position = (Vector2)transform.parent.position + _dirArr[_index] * 1f;
        _bullet.BulletShooted(_dirArr[_index]);
        _index++;
    }
}
