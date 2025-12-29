using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : PickedUpItem
{
    [SerializeField] private Weapon _weaponToPickUp; 

    public override void PickedUp(GameObject player)
    {
        WeaponsEquipped _weaponsEquipped = player.GetComponent<WeaponsEquipped>();
        if (_weaponToPickUp != null)
        {
            _weaponsEquipped.EquipWeapon(_weaponToPickUp);
        }
    }
}
