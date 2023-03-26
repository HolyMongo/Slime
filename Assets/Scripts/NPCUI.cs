using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCUI : MonoBehaviour
{
    QuestInventory player; 

    NPC _NPC;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestInventory>();
        _NPC = GetComponentInParent<NPC>();
    }
    public void Yes()
    {
        for (int i = 0; i < player.Quests.Length; i++)
        {
            if (player.Quests[i] != null)
            {
                Debug.Log("Next");
            }
            else if (player.Quests[i] == null)
            {
                player.Quests[i] = _NPC.Quest;
                QuestInventory.QuestScore += 1;
                player.questText.text = "Quests: " + QuestInventory.QuestScore;
                break;
            }

        }
    }
    public void Complete()
    {
        // Things
    }

}
