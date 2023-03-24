using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private Items item;

    public void Awake()
    {
        item = new Items();
        item.itemName = "Wood";
        item.health = 5;
        item.description = "Wood from a tree";
    }
    
    

    public Items GiveItem()
    {
        Destroy(gameObject);
        return item;
    }
}
