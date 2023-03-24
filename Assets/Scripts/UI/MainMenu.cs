using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string NewGameString;

    public void NewGame()
    {
        SceneManager.LoadScene(NewGameString);
    }
    public void LoadGame()
    {

    }
    public void Options()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
}
