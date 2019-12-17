 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Text starCountText; //text for now
    public GameObject winScreen;
    public GameObject loseScreen;

    public static int totalStarCount;

    public int maxStars;
    public int starCount;

    WindSwipe playerSwipe;

    // Start is called before the first frame update
    void Start()
    {
        starCount = 0;

        playerSwipe = FindObjectOfType<WindSwipe>();

        //by default, win and lose screens are set inactive at start
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStars();
    }

    public void UpdateStars()
    {
        starCountText.text = "Stars: " + starCount + "/" + maxStars;
    }

    public void LoseGame()
    {
        loseScreen.SetActive(true);
        playerSwipe.losesGame = true;
        //Time.timeScale = 0f;
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene(); //get the current active scene

        SceneManager.LoadScene(currentScene.name); //load the current scene by its name
        Time.timeScale = 1f; //reset the time scale back to 1
    }

    public void BackToMain()
    {
        Debug.Log("Going back to main");
    }

    public void Continue()
    {
        Debug.Log("Do nothing for now");
    }
}

