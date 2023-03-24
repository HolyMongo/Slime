using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Items item;

    public Items GiveItem()
    {
        Destroy(gameObject);
        return item;
    }
}
