using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


   public bool trueOfCourse1;
    public bool trueOfCourse2;
    public bool trueOfCourse3;
    // public SceneGameData sceneGameData;

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

        trueOfCourse1 = false;
        trueOfCourse2 = false;
        trueOfCourse3 = false;
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
