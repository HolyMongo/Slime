using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items")]
public class Items : ScriptableObject
{
    public string itemName;
    public int health;
    [TextArea(4, 4)]
    public string description;
}
