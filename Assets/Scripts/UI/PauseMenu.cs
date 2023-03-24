using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private string menu;
    [SerializeField] private GameObject isActive;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
        }
    }

    public void Continue()
    {
        isActive.SetActive(!false);
        Time.timeScale = 0;

    }
    public void SaveGame()
    {
        
    }
    public void LoadGame()
    {

    }
    
    public void Quit()
    {
        SceneManager.LoadScene(menu);
    }
}
