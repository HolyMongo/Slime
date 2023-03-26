using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public QuestSO Quest;

    public Image alreadyHaveQuest;
    public Image dontAlreadyHaveQuest;


   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            QuestInventory player = collision.gameObject.GetComponent<QuestInventory>();
            for (int i = 0; i < player.Quests.Length; i++)
            {
                if (player.Quests[i] != null)
                {
                    if (player.Quests[i].id == Quest.id)
                    {
                        alreadyHaveQuest.gameObject.SetActive(true);
                        break;
                    }
                }
                else if (player.Quests[i] == null)
                {
                    dontAlreadyHaveQuest.gameObject.SetActive(true);
                    return;

                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            QuestInventory player = collision.gameObject.GetComponent<QuestInventory>();
            for (int i = 0; i < player.Quests.Length; i++)
            {
                if (player.Quests[i] != null)
                {
                    if (player.Quests[i].id == Quest.id)
                    {
                        alreadyHaveQuest.gameObject.SetActive(true);
                        break;
                    }
                }
                else if (player.Quests[i] == null)
                {
                    dontAlreadyHaveQuest.gameObject.SetActive(true);
                    return;

                }

            }
        }
    }
}
