using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [SerializeField] private bool collected = false;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private PlayerStatsController player; 

    private void Start()
    {
        player = GameObject.Find("PlayerStats(Canvas)").GetComponent<PlayerStatsController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.UpdateItemText();
            collected = true;
            Destroy(this.gameObject);
          
        }
    }

    public void LoadData(GameData data)
    {
        data.itemCollected.TryGetValue(id, out collected);
    }
    public void SaveData(ref GameData data)
    {
        if(data.itemCollected.ContainsKey(id))
        {
            data.itemCollected.Remove(id);
        }
        data.itemCollected.Add(id, collected);
    }
}
