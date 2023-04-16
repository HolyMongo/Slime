using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;

    }

    public GameData Load(string profileId)
    {
        if(profileId == null)
        {
            return null;
        }


        // Use Path.Combine to account for different OSs having different path separators
        string fullpath = Path.Combine(dataDirPath, profileId, dataFileName);
        GameData loadedData = null;

        if(File.Exists(fullpath))
        {
            try
            {
                //Load the serialized data from the file
                string DataToLoad = "";
                using (FileStream stream = new FileStream(fullpath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        DataToLoad = reader.ReadToEnd();
                    }
                }

                //Deserialize the data from Json back into the C# object
                loadedData = JsonUtility.FromJson<GameData>(DataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullpath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(GameData data, string profileId)
    {

        if (profileId == null)
        {
            return;
        }

        // Use Path.Combine to account for different OSs having different path separators
        string fullpath = Path.Combine(dataDirPath, profileId, dataFileName);
        try
        {
            //Create the directory the file will be written to if it doesnt already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

            //Serialize the  C# game data object into json
            string dataToStore = JsonUtility.ToJson(data, true);

            //Write the serialized data to the file
            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullpath + "\n" + e);
        }
    }

    public Dictionary<string, GameData> LoadAllProfiles()
    {
        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();

        //Loop over all directory names in the data directory path
        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();
        foreach (DirectoryInfo dirInfo in dirInfos)
        {
            string profileId = dirInfo.Name;

            //Defensive programming, Check if the data file exists
            //If it doesnt, then this folder isnt a profile and should be skipped
            string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
            if(!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping directory when loading all profiles because it does not contain data: " + profileId);
                continue;
            }

            //Load the game data for this profile and put it in the directory
            GameData profileData = Load(profileId);
            //Defensive programming, ensure the profile data isnt null,
            //Because if it is then something went wrong and we should let ourselves know

            if(profileData != null)
            {
                profileDictionary.Add(profileId, profileData);
            }
            else
            {
                Debug.LogWarning("Tried to load profile but something went wrong. ProfileId: " + profileId);
            }
        }

        return profileDictionary;
    }

    public string GetMostRecentlyUpdatedProfileId()
    {
        string mostRecentProfileId = null;

        Dictionary<string, GameData> profilesGameData = LoadAllProfiles();
        foreach (KeyValuePair<string, GameData> pair in profilesGameData)
        {
            string profileId = pair.Key;
            GameData gameData = pair.Value;

            //Skip this entry if the gamedata is null
            if(gameData == null)
            {
                continue;
            }

            //If this is the first data we've come across that exists, its the most recent so far
            if(mostRecentProfileId == null)
            {
                mostRecentProfileId = profileId;
            }

            //Otherwise, compare to see which date is the most recent
            else
            {
                DateTime mostRecentDateTime = DateTime.FromBinary(profilesGameData[mostRecentProfileId].lastUpdated);
                DateTime newDateTime = DateTime.FromBinary(gameData.lastUpdated);
                if(newDateTime > mostRecentDateTime)
                {
                    mostRecentProfileId = profileId;
                }
            }
        }
        return mostRecentProfileId;
    }
}
