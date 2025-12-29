using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int _dmg;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _bulletLife;
    private Rigidbody2D _rb;

    private void Start()
    {
        Destroy(gameObject, _bulletLife);
    }

    public void BulletShooted(Vector2 direction)
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = direction*_speed;
        transform.right = direction;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
