using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEquipped : MonoBehaviour
{

    public void EquipWeapon(Weapon weapon)
    {
        Instantiate(weapon,transform);
    }
}
