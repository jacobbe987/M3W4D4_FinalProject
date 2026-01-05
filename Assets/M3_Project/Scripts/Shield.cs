using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PickedUpItem
{
    [SerializeField] private int _shieldToAdd;

    public override void PickedUp(GameObject player)
    {
        LifeController _lifeController = player.GetComponent<LifeController>();
        PlayerController _playerController = player.GetComponent<PlayerController>();
        if (_lifeController != null)
        {
            _lifeController.AddShield(_shieldToAdd);
            _playerController.Shield();
        }
    }
}
