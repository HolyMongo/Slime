using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneTransition : MonoBehaviour
{
    public string SceneToLoad;

    private void OnEnable()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
