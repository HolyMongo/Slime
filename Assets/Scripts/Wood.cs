using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public Items item;

    public Items GiveItem()
    {
        Destroy(gameObject);
        return item;
    }
}
