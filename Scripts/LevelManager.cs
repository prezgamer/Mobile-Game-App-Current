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

    public Image star1Win;
    public Image star2Win;
    public Image star3Win;

    public Sprite yellowStar;
    public Sprite nullStar;

    public string nameOfLevel;
    string stars;
    string highScore;

    //public Text starCountText; //text for now

    [Header("Screens")]
    public GameObject winScreen;
    public GameObject loseScreen;

    [Header("Stars Variables")]
    public static int totalStarCount;
    public GameObject starsHolder;
    public int maxStars;
    public int starCount;

    WindSwipe playerSwipe;
    CameraController theCam;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        LevelStrings();
        starsHolder.SetActive(true);

        starCount = 0;

       // PlayerPrefs.SetInt(stars, 0); //set starsCount to 0 by default
        PlayerPrefs.GetInt(highScore); //get the max stars count for this level

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
        CheckHighscore();

        Debug.Log(stars);
        Debug.Log(highScore);

        Debug.Log("stars in " + nameOfLevel + " Is " + PlayerPrefs.GetInt(stars, starCount));
    }

    void LevelStrings()
    {
        stars += nameOfLevel + " Stars";
        highScore += "Highscore of " + nameOfLevel;
    }

    public void CheckHighscore()
    {
        //check if the starcount is more than max stars or highscore in the current level
        if (starCount > PlayerPrefs.GetInt(highScore, 0))
        {
           // maxStars = starCount;
            PlayerPrefs.SetInt(highScore, maxStars);
            maxStars = starCount;
        }
    }

    public void UpdateStars()
    {
        //set the starsCount to be the same as the cases
        switch (starCount)
        {
            case 0:
                star1.sprite = nullStar;
                star2.sprite = nullStar;
                star3.sprite = nullStar;

                star1Win.sprite = nullStar;
                star2Win.sprite = nullStar;
                star3Win.sprite = nullStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;

            case 1:
                star1.sprite = yellowStar;
                star2.sprite = nullStar;
                star3.sprite = nullStar;

                star1Win.sprite = yellowStar;
                star2Win.sprite = nullStar;
                star3Win.sprite = nullStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;

            case 2:
                star1.sprite = yellowStar;
                star2.sprite = yellowStar;
                star3.sprite = nullStar;

                star1Win.sprite = yellowStar;
                star2Win.sprite = yellowStar;
                star3Win.sprite = nullStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;

            case 3:
                star1.sprite = yellowStar;
                star2.sprite = yellowStar;
                star3.sprite = yellowStar;

                star1Win.sprite = yellowStar;
                star2Win.sprite = yellowStar;
                star3Win.sprite = yellowStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;

            default:
                star1.sprite = nullStar;
                star2.sprite = nullStar;
                star3.sprite = nullStar;

                star1Win.sprite = nullStar;
                star2Win.sprite = nullStar;
                star3Win.sprite = nullStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;
        }
    }

    public void LoseGame()
    {
        loseScreen.SetActive(true);
        playerSwipe.losesGame = true;
        theCam.followPlayer = false;
        starsHolder.SetActive(false);
        //Time.timeScale = 0f;
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        starsHolder.SetActive(false);
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

