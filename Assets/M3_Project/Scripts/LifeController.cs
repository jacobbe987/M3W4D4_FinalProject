using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _Hp;
    [SerializeField] private int _maxHp;

    public int Hp { get => _Hp; set => SetHp(value); }
    public int MaxHp { get => _maxHp; set => SetMaxHp(value); }

    private void SetHp( int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);
        if(hp != _Hp)
        {
            _Hp = hp;
        }
    }

    private void SetMaxHp (int maxHp)
    {
        _maxHp = maxHp;
    }

    public void AddHp (int value)
    {
        SetHp(_Hp + value);
    }

    public void RemoveHp(int value)
    {
        SetHp(_Hp - value);
    }
}
