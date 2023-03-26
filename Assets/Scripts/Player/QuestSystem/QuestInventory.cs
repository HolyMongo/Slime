using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestInventory : MonoBehaviour
{
    public QuestSO[] Quests;
    public static QuestInventory _instance;

    public TMP_Text questText;
    private static int questScore = 0;

    public static int QuestScore
    {
        get
        {
            return questScore;
        }
        set
        {
            questScore = value;
        }
    }

    private void Awake()
    {
        _instance = this;
        Quests = new QuestSO[10];
        for (int i = 0; i < Quests.Length; i++)
        {
            if(Quests[i] != null)
            {
                questText.text = "Quests: " + QuestScore;
            }
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Finish"))
    //    {
    //        other.gameObject.GetComponent<NPC>().AddQuest(_instance);

    //    }
    //}


}
