using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Screen Variables")]
    public GameObject mainMenu;
    public GameObject creditPage;
    public GameObject levelSelectScreen;
    public GameObject clearPlayerprefsScreen;
    public Animator loadingScreen;

    private void Start()
    {
        //close level select and Credit Page and open main menu by default
        CloseLevelSelect(); 
        CloseCreditPage(); 
        clearPlayerprefsScreen.SetActive(false);
    }

    public void StartGame()
    {
        //load level 1 for now
        SceneManager.LoadScene("GameScene");
    }

    //opens level selection
    public void OpenLevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelectScreen.SetActive(true);
    }

    //closes level selection
    public void CloseLevelSelect()
    {
        mainMenu.SetActive(true);
        levelSelectScreen.SetActive(false);
    }

    public void OpenCreditPage()
    {
        creditPage.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseCreditPage()
    {
        creditPage.SetActive(false);
        mainMenu.SetActive(true);
    }

    //load level with selected scene name
    public void LoadSelectedLevel(string selectedScene)
    {
        //StartCoroutine(LoadingGame(loadingScreen, selectedScene));
        SceneManager.LoadScene(selectedScene); //load selected scene name
        Time.timeScale = 1f;
    }

    public void NoClear()
    {
        clearPlayerprefsScreen.SetActive(false);
    }

    public void YesClear()
    {
        PlayerPrefs.DeleteAll(); //clear all in game data

        SceneManager.LoadScene("Main Menu");
    }


    public void ClearPlayerprefs()
    {
        clearPlayerprefsScreen.SetActive(true);
    }

    //quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadingGame(Animator loadingScreenAnim, string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName); //load scene in background

        loadingScreenAnim.SetTrigger("StartLoading"); //play the starting of loading screen

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        loadingScreenAnim.SetTrigger("EndLoading"); //play the ending of the loading screen
    }
}
