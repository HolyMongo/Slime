using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string SceneToLoad;
    public int secBeforeLoadingScene = 1;
    public Animator anim;

    public void LoadScene()
    {
        StartCoroutine(LoadNextScene());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(secBeforeLoadingScene);

        SceneManager.LoadScene(SceneToLoad);
    }
}
