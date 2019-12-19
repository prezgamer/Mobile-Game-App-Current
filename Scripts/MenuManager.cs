using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Screen Variables")]
    public GameObject mainMenu;
    public GameObject levelSelectScreen;
    public GameObject clearPlayerprefsScreen;

    private void Start()
    {
        CloseLevelSelect(); //close level select and open main menu by default
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

    //load level with selected scene name
    public void LoadSelectedLevel(string selectedScene)
    {
        SceneManager.LoadScene(selectedScene);
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
        //clearPlayerprefsScreen.SetActive(false); //turn screen off
        //CloseLevelSelect(); //go back to starting game screen
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
}
