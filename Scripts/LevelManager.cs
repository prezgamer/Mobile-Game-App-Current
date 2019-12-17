 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Stars Variables")]
    public Image star1;
    public Image star2;
    public Image star3;

    public Sprite yellowStar;
    public Sprite nullStar;
    //public Text starCountText; //text for now

    [Header("Screens")]
    public GameObject winScreen;
    public GameObject loseScreen;

    public static int totalStarCount;

    public int maxStars;
    public int starCount;

    WindSwipe playerSwipe;
    CameraController theCam;

    // Start is called before the first frame update
    void Start()
    {
        starCount = 0;

        playerSwipe = FindObjectOfType<WindSwipe>();
        theCam = FindObjectOfType<CameraController>();

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
        //starCountText.text = "Stars: " + starCount + "/" + maxStars;

        switch (starCount)
        {
            case 0:
                star1.sprite = nullStar;
                star2.sprite = nullStar;
                star3.sprite = nullStar;
                break;

            case 1:
                star1.sprite = yellowStar;
                star2.sprite = nullStar;
                star3.sprite = nullStar;
                break;

            case 2:
                star1.sprite = yellowStar;
                star2.sprite = yellowStar;
                star3.sprite = nullStar;
                break;

            case 3:
                star1.sprite = yellowStar;
                star2.sprite = yellowStar;
                star3.sprite = yellowStar;
                break;

            default:
                star1.sprite = nullStar;
                star2.sprite = nullStar;
                star3.sprite = nullStar;
                break;
        }
    }

    public void LoseGame()
    {
        loseScreen.SetActive(true);
        playerSwipe.losesGame = true;
        theCam.followPlayer = false;
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
        SceneManager.LoadScene("Main Menu");
        //Debug.Log("Going back to main");
    }

    public void Continue()
    {
        Debug.Log("Do nothing for now");
    }
}

