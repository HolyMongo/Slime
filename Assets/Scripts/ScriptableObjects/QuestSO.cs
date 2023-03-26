using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class QuestSO : ScriptableObject
{
    public string questName;
    [TextArea(4, 4)]
    public string description;
    public int id;
}
