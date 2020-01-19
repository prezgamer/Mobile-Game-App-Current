 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Variables
    [Header("Stars Variables")]
    public Image star1;
    public Image star2;
    public Image star3;
    public Image star1Win;
    public Image star2Win;
    public Image star3Win;
    public Sprite yellowStar;
    public Sprite nullStar;

    [Header("PlayerPrefs Variables")]
    public string nameOfLevel;
    string stars;
    string highScore;

    [Header("Audio Source Variables")]
    public AudioSource clappingSound;

    //public Text starCountText; //text for now
    [Header("Boolean Variables")]
    public static bool runGame = true;
    public bool turnOnEffects = true;
    //public bool gameIsRunning = true;

    [Header("Screens")]
    public GameObject winScreen;
    public GameObject loseScreen;
    public bool gameIsLost = false;

    [Header("Stars Variables")]
    public static int totalStarCount;
    public GameObject starsHolder;
    public int maxStars;
    public int starCount;

    WindSwipe playerSwipe;
    CameraController theCam;
    StarScript theStars;
    #endregion

    private void Awake()
    {
        runGame = true;
        turnOnEffects = true;
        //gameIsRunning = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelStrings();
        starsHolder.SetActive(true);

        starCount = 0;

        PlayerPrefs.GetInt(highScore); //get the max stars count for this level

        playerSwipe = FindObjectOfType<WindSwipe>();
        theStars = FindObjectOfType<StarScript>();
        theCam = FindObjectOfType<CameraController>();

        //by default, win and lose screens are set inactive at start
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    private void Update()
    {
        UpdateStars();
    }

    #region Audio Functions
    public static void PlayAudioSource(AudioSource audioSource)
    {
        audioSource.Play();
    }
    #endregion

    #region String Function
    void LevelStrings()
    {
        stars += nameOfLevel + " Stars";
        highScore += "Highscore of " + nameOfLevel;
    }
    #endregion

    #region Highscore Function
    public void CheckHighscore()
    {
        //check if the starcount is more than max stars or highscore in the current level
        if (starCount > PlayerPrefs.GetInt(highScore, 0))
        {
            PlayerPrefs.SetInt(highScore, maxStars);
            maxStars = starCount;
        }
    }
    #endregion

    #region Update Stars Count Functions
    public void UpdateStars()
    {
        //set the starsCount to be the same as the cases
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

    //update the win screen stars count
    public void UpdateWinScreen()
    {
        switch (starCount)
        {
            case 0:
                star1Win.sprite = nullStar;
                star2Win.sprite = nullStar;
                star3Win.sprite = nullStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;

            case 1:
                star1Win.sprite = yellowStar;
                star2Win.sprite = nullStar;
                star3Win.sprite = nullStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;

            case 2:
                star1Win.sprite = yellowStar;
                star2Win.sprite = yellowStar;
                star3Win.sprite = nullStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;

            case 3:
                star1Win.sprite = yellowStar;
                star2Win.sprite = yellowStar;
                star3Win.sprite = yellowStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;

            default:
                star1Win.sprite = nullStar;
                star2Win.sprite = nullStar;
                star3Win.sprite = nullStar;

                PlayerPrefs.SetInt(stars, starCount);
                break;
        }
    }
    #endregion

    #region Screen and Changing Scene Functions
    public void LoseGame()
    {
        gameIsLost = true;
        loseScreen.SetActive(true);
        playerSwipe.losesGame = true;
        theCam.followPlayer = false;
        starsHolder.SetActive(false);
    }

    public void WinGame()
    {
        PlayAudioSource(clappingSound);
        winScreen.SetActive(true);
        starsHolder.SetActive(false);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        turnOnEffects = false;
        Scene currentScene = SceneManager.GetActiveScene(); //get the current active scene

        SceneManager.LoadScene(currentScene.name); //load the current scene by its name
        Time.timeScale = 1f; //reset the time scale back to 1
    }

    public void BackToMain()
    {
        turnOnEffects = false;
        SceneManager.LoadScene("Main Menu"); //return to main menu
        Time.timeScale = 1f;
    }

    public void Continue(string nextLevelName)
    {
        turnOnEffects = false;
        SceneManager.LoadScene(nextLevelName); //load next level scene by its name
        Time.timeScale = 1f;
    }
    #endregion
}

