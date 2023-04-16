using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour // This is a singleton class, we only want one of this script for every scene
{
    [Header("Debugging")]
    [SerializeField] private bool disableDataPersistence = false;
    [SerializeField] private bool initializeDataIfNull = false;
    [SerializeField] private bool overrideSelectedProfileId = false;
    [SerializeField] private string testSelectedProfileId = "test";


    [Header("File Storage Config")]
    [SerializeField] private string fileName;


    private GameData gameData;

    private List<IDataPersistence> dataPersistencesObjects;

    private FileDataHandler dataHandler;

    private string selectedProfileId = "";

    public static DataPersistenceManager Instance{ get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Unexpected error, more than one Data Persistence Manager was found. Only one is allowed");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        if(disableDataPersistence)
        {
            Debug.LogWarning("Data Persistence is currently disabled!");
        }

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);

        this.selectedProfileId = dataHandler.GetMostRecentlyUpdatedProfileId();

        if(overrideSelectedProfileId)
        {
            this.selectedProfileId = testSelectedProfileId;
            Debug.LogWarning("Overrode selected profile id with test");
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
       
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
       
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded");
        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnloaded");
        SaveGame();
    }

    public void ChangeSelectedProfileId(string newProfileId)
    {
        this.selectedProfileId = newProfileId;
        LoadGame();
    }

    private void Start()
    {
        
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        if(disableDataPersistence)
        {
            return;
        }

        //Load  any saved data from a file using the data handler
        this.gameData = dataHandler.Load(selectedProfileId);

        if(this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        //If no data can be loaded, then initialize to a new game
        if(this.gameData == null)
        {
            Debug.LogError("No data was found. A new game needs to be started before data can be loaded(Or else it wont work)");
            return;
        }

        //Push the loaded data to all other scripts that need it
        foreach(IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        Debug.Log("Loaded death count = " + gameData.DeathCount);
    }

    public void SaveGame()
    {

        if (disableDataPersistence)
        {
            return;
        }

        //If we dont have any data to save
        if (this.gameData == null)
        {
            Debug.Log("No data was found. A new game needs to be started before data can be loaded(Or else it wont work)");
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        Debug.Log("Saved death count = " + gameData.DeathCount);

        gameData.lastUpdated = System.DateTime.Now.ToBinary();

        Scene scene = SceneManager.GetActiveScene();
        if (!scene.name.Equals("MainMenu"))
        {
            gameData.currentSceneName = scene.name;
        }

        //Save that data to a file using the data handler
        dataHandler.Save(gameData, selectedProfileId);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public string GetSavedSceneName()
    {
        //If no data could be found(If we dont have any game data yet)
        if(gameData == null)
        {
            Debug.LogError("Tried to get scene name but data was null");
            return null;
        }

        //Otherwise, return that value from our data
        return gameData.currentSceneName;
    }

    public bool HasGameData()
    {
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
}
