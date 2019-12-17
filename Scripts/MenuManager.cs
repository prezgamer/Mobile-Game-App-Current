using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Screen Variables")]
    public GameObject mainMenu;
    public GameObject levelSelectScreen;

    private void Start()
    {
        CloseLevelSelect(); //close level select and open main menu by default
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
    }

    //quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
