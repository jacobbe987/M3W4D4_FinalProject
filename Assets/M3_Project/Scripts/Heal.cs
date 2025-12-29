using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : PickedUpItem
{
    [SerializeField] private int _healToRecover;

    public override void PickedUp(GameObject player)
    {
        LifeController _lifeController = player.GetComponent<LifeController>();
        if (_lifeController != null)
        {
            _lifeController.AddHp(_healToRecover);
        }
    }
}
