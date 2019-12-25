using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
    }

    #region Screen and Scene Functions
    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene(); //get the current active scene

        SceneManager.LoadScene(currentScene.name); //load the current scene by its name
        Time.timeScale = 1f; //reset the time scale back to 1
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f; //resume game
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        FindObjectOfType<WindSwipe>().isPaused = false; //allow player to deplete wind power
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        FindObjectOfType<WindSwipe>().isPaused = true; //dont allow player to deplete wind power
        pauseScreen.SetActive(true);
    }
    #endregion
}
