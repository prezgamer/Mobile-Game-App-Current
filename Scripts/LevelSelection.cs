using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public int levelNum;

    public int[] starsHighscore;

    public Image[] stars1;
    public Image[] stars2;
    public Image[] stars3;

    public Sprite emptyStar;
    public Sprite filledStar;

    public GameObject[] unlockedLevels;
    public GameObject[] lockedLevels;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsFunctions();
    }

    // Update is called once per frame
    void Update()
    {
        //unlock the levels respectively
        UpdateLevels(0);
        UpdateLevels(1);
        UpdateLevels(2);
        UpdateLevels(3);
        UpdateLevels(4);
        UpdateLevels(5);

        PlayerPrefsFunctions();
    }

    #region PlayerPrefs Starting Functions
    void PlayerPrefsFunctions()
    {
        PlayerPrefs.GetInt("Max Levels");

        //if the level unlock is more, override the max levels and set to that number
        if (PlayerPrefs.GetInt("Level Unlocked", levelNum) > PlayerPrefs.GetInt("Max Levels"))
        {
            PlayerPrefs.SetInt("Max Levels", PlayerPrefs.GetInt("Level Unlocked")); //set the max num to be the same as the level unlocked
        }

        //if max levels is more, override the level num to be always be the same as max levels
        if (PlayerPrefs.GetInt("Max Levels") > PlayerPrefs.GetInt("Level Unlocked", levelNum))
        {
            levelNum = PlayerPrefs.GetInt("Max Levels");
            PlayerPrefs.SetInt("Level Unlocked", levelNum);
        }

        //retreive the number of stars which player has gotten on each level
        PlayerPrefs.GetInt("Level 1 Stars", starsHighscore[0]);
        PlayerPrefs.GetInt("Level 2 Stars", starsHighscore[1]);
        PlayerPrefs.GetInt("Level 3 Stars", starsHighscore[2]);
        PlayerPrefs.GetInt("Level 4 Stars", starsHighscore[3]);
        PlayerPrefs.GetInt("Level 5 Stars", starsHighscore[4]);
        PlayerPrefs.GetInt("Level 6 Stars", starsHighscore[5]);

        //check if less stars does not override the max stars collected for each level
        for (int levelNum = 1; levelNum <= 6; levelNum++)
        {
            CheckStarCount("Level " + levelNum + "Stars", "Max Level " + levelNum + " Stars");
        }

        //update the stars based on each level collection of stars
        UpdateStars("Level 1 Stars", 0);
        UpdateStars("Level 2 Stars", 1);
        UpdateStars("Level 3 Stars", 2);
        UpdateStars("Level 4 Stars", 3);
        UpdateStars("Level 5 Stars", 4);
        UpdateStars("Level 6 Stars", 5);
    }
    #endregion

    #region Check Star Count Functions
    void CheckStarCount(string levelStars, string maxLevelStars)
    {
        //if level stars is more, set the max level stars to be level stars
        if (PlayerPrefs.GetInt(levelStars) > PlayerPrefs.GetInt(maxLevelStars))
        {
            PlayerPrefs.SetInt(maxLevelStars, (PlayerPrefs.GetInt(levelStars))); 
        }

        PlayerPrefs.SetInt(levelStars, PlayerPrefs.GetInt(maxLevelStars)); //set the level stars to be max level stars
    }

    //update the number of stars gotten on each level
    void UpdateStars(string levelStars, int levelNum)
    {
        if (PlayerPrefs.GetInt(levelStars, starsHighscore[levelNum]) == 0)
        {
            stars1[levelNum].sprite = emptyStar;
            stars2[levelNum].sprite = emptyStar;
            stars3[levelNum].sprite = emptyStar;
        }

        if (PlayerPrefs.GetInt(levelStars, starsHighscore[levelNum]) == 1)
        {
            stars1[levelNum].sprite = filledStar;
            stars2[levelNum].sprite = emptyStar;
            stars3[levelNum].sprite = emptyStar;
        }

        if (PlayerPrefs.GetInt(levelStars, starsHighscore[levelNum]) == 2)
        {
            stars1[levelNum].sprite = filledStar;
            stars2[levelNum].sprite = filledStar;
            stars3[levelNum].sprite = emptyStar;
        }

        if (PlayerPrefs.GetInt(levelStars, starsHighscore[levelNum]) >= 3)
        {
            stars1[levelNum].sprite = filledStar;
            stars2[levelNum].sprite = filledStar;
            stars3[levelNum].sprite = filledStar;
        }
    }
    #endregion

    #region Level Unlock Functions
    //unlock the levels 
    void UnlockedLevels(GameObject unlockedLvl, GameObject lockedLvl)
    {
        unlockedLvl.SetActive(true);
        lockedLvl.SetActive(false);
    }

    //updates the levels that have been unlocked
    public void UpdateLevels(int numOfLevelsUnlocked)
    {
        if (PlayerPrefs.GetInt("Level Unlocked") == numOfLevelsUnlocked)
        {
            for (int levelUnlock = 0; levelUnlock <= numOfLevelsUnlocked; levelUnlock++)
            {
                UnlockedLevels(unlockedLevels[levelUnlock], lockedLevels[levelUnlock]); //unlock level 1
            }
        }
    }
    #endregion
}
