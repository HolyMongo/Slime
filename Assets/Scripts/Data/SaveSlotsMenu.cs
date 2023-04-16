using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;


    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }
   
    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        DataPersistenceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
        if(!isLoadingGame)
        {
            DataPersistenceManager.Instance.NewGame();
            DataPersistenceManager.Instance.SaveGame();
            SceneManager.LoadSceneAsync("BeforeIntro");       
        }
        else
        {
            DataPersistenceManager.Instance.SaveGame();
            SceneManager.LoadSceneAsync(DataPersistenceManager.Instance.GetSavedSceneName());
        }
        
    }


    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    public void ActivateMenu(bool isLoadingGame)
    {
        this.gameObject.SetActive(true);

        this.isLoadingGame = isLoadingGame;

        //Load all of the profiles that exist
        Dictionary<string, GameData> profilesGamedata = DataPersistenceManager.Instance.GetAllProfilesGameData();

     
        foreach (SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGamedata.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            if(profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
               
            }
        }
      

    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
          
        }
        backButton.interactable = false;
    }
}
