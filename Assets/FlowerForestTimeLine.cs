using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FlowerForestTimeLine : MonoBehaviour, IDataPersistence
{
    public PlayableDirector _currentDirector;
    //private bool _sceneSkipped = true;
    //private float _timeToSkipTo;
    public GameObject obj;
    private GameData gameData;
    private DataPersistenceManager dataManager;


    // Start is called before the first frame update
    void Awake()
    {
        //if(gameData.IntroTimeLineHasPlayed == false)
        //{
        //    _currentDirector.Play();
        //    gameData.IntroTimeLineHasPlayed = true;
        //    dataManager.SaveGame();
        //}
        if(gameData.IntroTimeLineHasPlayed == false)
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadData(GameData data)
    {
       
        data.IntroTimeLineHasPlayed = false;
    }
    public void SaveData(ref GameData data)
    {
        if (data.IntroTimeLineHasPlayed == false)
        {
            data.IntroTimeLineHasPlayed = true;
        }
        else if (data.IntroTimeLineHasPlayed == false)
        {
            obj.SetActive(false);
        }
     
    }
}
