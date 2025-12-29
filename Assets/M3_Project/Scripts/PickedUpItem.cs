using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickedUpItem : MonoBehaviour
{
    public abstract void PickedUp(GameObject player);
}
