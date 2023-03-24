using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Items[] itemInventory;
    [SerializeField] private bool[] isFull;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PickUp"))
        {
            for (int i = 0; i < itemInventory.Length; i++)
            {
                if (isFull[i] == false)
                {
                    //Adding Item
                    isFull[i] = true;
                    itemInventory[i] = collision.collider.GetComponent<PickUp>().GiveItem();
                    return;
                }
            }
        }
    }

    public void AddItem()
    {
        //Add Item
    }
}
