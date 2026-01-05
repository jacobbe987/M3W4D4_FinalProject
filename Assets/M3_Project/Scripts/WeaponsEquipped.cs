using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEquipped : MonoBehaviour
{
    [SerializeField] Weapon _startWeapon;

    public void Start()
    {
        EquipWeapon(_startWeapon);

    }
    public void EquipWeapon(Weapon weapon)
    {
        Instantiate(weapon, transform);

    }
}
