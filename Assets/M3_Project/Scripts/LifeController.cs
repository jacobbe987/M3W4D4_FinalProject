using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _Hp;
    [SerializeField] private int _maxHp;

    [SerializeField] private int _shield;
    [SerializeField] private int _maxShield;

    public int Hp { get => _Hp; set => SetHp(value); }
    public int MaxHp { get => _maxHp; set => SetMaxHp(value); }

    public int Shield { get => _shield; set => SetShield(value); }
    public int MaxShield { get => _maxShield; set => SetMaxShield(value); }

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

    private void SetShield(int shield)
    {
        shield = Mathf.Clamp(shield, 0, _maxHp);
        if (shield != _shield)
        {
            _shield = shield;
        }
    }

    private void SetMaxShield(int maxShield)
    {
        _maxShield = maxShield;
    }

    public void AddShield(int value)
    {
        SetShield(_shield + value);
    }

    public void RemoveShield(int value)
    {
        SetShield(_shield - value);
    }
}
