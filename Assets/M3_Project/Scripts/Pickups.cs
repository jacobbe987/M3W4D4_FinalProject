using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    private PickedUpItem _pickedUpItem;

    private void Awake()
    {
        _pickedUpItem = GetComponent<PickedUpItem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (_pickedUpItem != null)
            {
                _pickedUpItem.PickedUp(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
