using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionScripts : MonoBehaviour
{
    public Animator transitonAnim;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadMainMenu());
    }

    public void QuitGame()
    {
        StartCoroutine(ExitGame());
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        transitonAnim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadMainMenu()
    {
        transitonAnim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(0);
    }

    IEnumerator ExitGame()
    {
        transitonAnim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        Debug.Log("GameQuit"); 
        Application.Quit();
    }

}
