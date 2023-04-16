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

    public bool IntroTimeLineHasPlayed;

    public int currentLvl;
    public int currentExp;

    // The values defined in this constructor will be the default values
    // The game starts with when there no data to lead. So the first time you start the game

    public GameData()
    {
        currentSceneName = "Intro";
        this.DeathCount = 0;
        this.PlayerPosition = new Vector3(-16f, -0.5f, 0f);
        itemCollected = new SerializableDictionary<string, bool>();
        IntroTimeLineHasPlayed = false;
        currentLvl = 0;
        currentExp = 0;
    }

    public int GetPercentageComplete() // Den h�r metoden anv�nds f�r att r�kna ut hur m�nga % av spelet som �r avklarad, dess UI �r just nu avst�ngd
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
