using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int waitingBeforeLoading = 3;

    string activeSceneName;
    Scene activeScene;

    private void Awake()
    {
        activeSceneName = SceneManager.GetActiveScene().name;
        activeScene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        //Debug.Log("Aktif sahne is = " + activeScene);
        if (activeSceneName == "Splash Screen")
        {
            LevelLoading();
        }
    }

    public void LevelLoading()
    {
        StartCoroutine(WaitingForLoading());
    }

    IEnumerator WaitingForLoading()
    {
        yield return new WaitForSeconds(waitingBeforeLoading);
        SceneManager.LoadScene(activeScene.buildIndex+1);
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Lost Screen");
    }

    public void RestartTheLevel()
    {
        SceneManager.LoadScene(activeScene.buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }

}
