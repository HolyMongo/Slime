using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInventory : MonoBehaviour
{
    public QuestSO[] Quests;
    public static QuestInventory _instance;

    private void Awake()
    {
        _instance = this;
        Quests = new QuestSO[10];
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Finish"))
    //    {
    //        other.gameObject.GetComponent<NPC>().AddQuest(_instance);

    //    }
    //}


}
