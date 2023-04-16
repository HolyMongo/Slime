using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData // Vad som ska sparas
{
    public long lastUpdated;

    public string currentSceneName;

    public int DeathCount;

    public Vector3 PlayerPosition;

    public SerializableDictionary<string, bool> itemCollected;

    // The values defined in this constructor will be the default values
    // The game starts with when there no data to lead. So the first time you start the game

    public GameData()
    {
        currentSceneName = "Intro";
        this.DeathCount = 0;
        this.PlayerPosition = new Vector3(-329.46f, -60.036f, 0f);
        itemCollected = new SerializableDictionary<string, bool>();   
    }

    public int GetPercentageComplete() // Den här metoden används för att räkna ut hur många % av spelet som är avklarad, dess UI är just nu avstängd
    {
        //How many items we collected
        int totalCollected = 0;

        foreach (bool collected in itemCollected.Values)
        {
            if(collected)
            {
                totalCollected++;
            }
        }

        //Ensure we dont divide be 0 when calculating the percentage
        int percentageCompleted = -1;
        if(itemCollected.Count != 0)
        {
            percentageCompleted = (totalCollected * 100 / itemCollected.Count);
        }
        return percentageCompleted;
    }

    

}
