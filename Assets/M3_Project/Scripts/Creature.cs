using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] protected string _name;
    
    protected LifeController _lifeController;

    protected virtual void Awake()
    {
        _lifeController = GetComponent<LifeController>();
        
    }

    public virtual void Hitted( int damage)
    {
        if( _lifeController.Shield != 0 && _lifeController.Shield >= damage)
        {
            _lifeController.RemoveShield(damage);
        }
        else if (_lifeController.Shield < damage)
        {
            int _damageToLife = damage - _lifeController.Shield;
            _lifeController.RemoveShield(_lifeController.Shield);
            _lifeController.RemoveHp(_damageToLife);
            GameObject _shield = GameObject.FindGameObjectWithTag("Shield");
            Destroy(_shield);
        }
        else if (_lifeController.Shield == 0)
        {
            _lifeController.RemoveHp(damage);
        }
    }

    public virtual void Dead()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,1f);
    }
}
