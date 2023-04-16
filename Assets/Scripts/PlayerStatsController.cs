using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsController : MonoBehaviour, IDataPersistence
{
    // Player Death count
    public TMP_Text DeathText;
    public  int deathCount = 0;

    // Player item count
    public TMP_Text ItemText;
    public int ItemCount = 0;
    public static PlayerStatsController Instance { get; private set; }
   
    [SerializeField] private GameObject isActive;

  
    void Start()
    {
        DeathText.text = "Deaths " + deathCount;
        ItemText.text = "Collected Items " + ItemCount;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Continue();
        }
    }
    public void Continue()
    {
        if (isActive.activeInHierarchy == true)
        {
            isActive.SetActive(false);
        }
        else
        {
            isActive.SetActive(true);
        }
    }
    public void UpdateHealthText()
    {
        deathCount++;
        DeathText.text = "Deaths " + deathCount;
      
    }

    public void UpdateItemText()
    {
      ItemCount++;
        ItemText.text = "Collected Items " + ItemCount;
    }

    public void LoadData(GameData data)
    {
       this.deathCount = data.DeathCount;
        foreach (KeyValuePair<string, bool> pair in data.itemCollected)
        {
            if (pair.Value)
            {
                ItemCount++;
            }
        }
    }
    public void SaveData(ref GameData data)
    {

        data.DeathCount = this.deathCount;
        //deathCount++;
        //DeathText.text = "Deaths " + deathCount;
    }
}
