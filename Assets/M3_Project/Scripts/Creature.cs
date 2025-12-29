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
        _lifeController.RemoveHp(damage);
    }

    public virtual void Dead()
    {
        
        Destroy(gameObject);
    }
}
