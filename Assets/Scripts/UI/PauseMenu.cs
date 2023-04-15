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
       if(isActive.activeInHierarchy == true)
        {
            isActive.SetActive(false);
        }
       else
        {
            isActive.SetActive(true);
        }
        if(Time.timeScale <= 0)
        {
            Time.timeScale = 1;
        }
        else if(Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }

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
