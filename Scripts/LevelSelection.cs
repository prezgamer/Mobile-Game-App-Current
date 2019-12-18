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

    private void Awake()
    {
        WarningsForArrays();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsFunctions();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevels();

        WarningsForArrays();
    }

    void PlayerPrefsFunctions()
    {
        PlayerPrefs.GetInt("Level Unlocked", levelNum); //get the number of levels that are unlocked

        //Debug.Log("The number is " + PlayerPrefs.GetInt("Level 1 Stars", starsHighscore[0]));

        //retreive the number of stars which player has gotten on each level
        PlayerPrefs.GetInt("Level 1 Stars", starsHighscore[0]);
        PlayerPrefs.GetInt("Level 2 Stars", starsHighscore[1]);
        PlayerPrefs.GetInt("Level 3 Stars", starsHighscore[2]);
        PlayerPrefs.GetInt("Level 4 Stars", starsHighscore[3]);
        PlayerPrefs.GetInt("Level 5 Stars", starsHighscore[4]);
        PlayerPrefs.GetInt("Level 6 Stars", starsHighscore[5]);

        UpdateStars("Level 1 Stars", 0);
        UpdateStars("Level 2 Stars", 1);
        UpdateStars("Level 3 Stars", 2);
        UpdateStars("Level 4 Stars", 3);
        UpdateStars("Level 5 Stars", 4);
        UpdateStars("Level 6 Stars", 5);
    }

    //update the number of stars gotton on each level
    void UpdateStars(string levelStars, int levelNum)
    {
        if (PlayerPrefs.GetInt(levelStars, starsHighscore[levelNum]) == 0)
        {
            stars1[levelNum].sprite = emptyStar;
            stars2[levelNum].sprite = emptyStar;
            stars3[levelNum].sprite = emptyStar;
            //Debug.Log("stars are empty at " + "Level " + (levelNum += 1));
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
           // Debug.Log("stars have been filled at " + "Level " + (levelNum += 1));
        }

    }

    #region Array Warnings
    void WarningsForArrays()
    {
        if (unlockedLevels[0] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + unlockedLevels[0].name);
        }

        if (unlockedLevels[1] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + unlockedLevels[1].name);
        }

        if (unlockedLevels[2] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + unlockedLevels[2].name);
        }

        if (unlockedLevels[3] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + unlockedLevels[3].name);
        }

        if (unlockedLevels[4] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + unlockedLevels[4].name);
        }

        if (unlockedLevels[5] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + unlockedLevels[5].name);
        }

        if (lockedLevels[0] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + lockedLevels[0].name);
        }

        if (lockedLevels[1] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + lockedLevels[1].name);
        }

        if (lockedLevels[2] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + lockedLevels[2].name);
        }

        if (lockedLevels[3] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + lockedLevels[3].name);
        }

        if (lockedLevels[4] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + lockedLevels[4].name);
        }

        if (lockedLevels[5] == null)
        {
            Debug.LogWarning("no gameobj is being loaded in " + lockedLevels[5].name);
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
    public void UpdateLevels()
    {
        if (PlayerPrefs.GetInt("Level Unlocked") == 0)
        {
            UnlockedLevels(unlockedLevels[0], lockedLevels[0]); //unlock level 1
        }

        if (PlayerPrefs.GetInt("Level Unlocked") == 1)
        {
            UnlockedLevels(unlockedLevels[0], lockedLevels[0]); //unlock level 1
            UnlockedLevels(unlockedLevels[1], lockedLevels[1]); //unlock level 2
        }

        if (PlayerPrefs.GetInt("Level Unlocked") == 2)
        {
            UnlockedLevels(unlockedLevels[0], lockedLevels[0]); //unlock level 1
            UnlockedLevels(unlockedLevels[1], lockedLevels[1]); //unlock level 2
            UnlockedLevels(unlockedLevels[2], lockedLevels[2]); //unlock level 3
        }

        if (PlayerPrefs.GetInt("Level Unlocked") == 3)
        {
            UnlockedLevels(unlockedLevels[0], lockedLevels[0]); //unlock level 1
            UnlockedLevels(unlockedLevels[1], lockedLevels[1]); //unlock level 2
            UnlockedLevels(unlockedLevels[2], lockedLevels[2]); //unlock level 3
            UnlockedLevels(unlockedLevels[3], lockedLevels[3]); //unlock level 4
        }

        if (PlayerPrefs.GetInt("Level Unlocked") == 4)
        {
            UnlockedLevels(unlockedLevels[0], lockedLevels[0]); //unlock level 1
            UnlockedLevels(unlockedLevels[1], lockedLevels[1]); //unlock level 2
            UnlockedLevels(unlockedLevels[2], lockedLevels[2]); //unlock level 3
            UnlockedLevels(unlockedLevels[3], lockedLevels[3]); //unlock level 4
            UnlockedLevels(unlockedLevels[4], lockedLevels[4]); //unlock level 5
        }

        if (PlayerPrefs.GetInt("Level Unlocked") == 5)
        {
            UnlockedLevels(unlockedLevels[0], lockedLevels[0]); //unlock level 1
            UnlockedLevels(unlockedLevels[1], lockedLevels[1]); //unlock level 2
            UnlockedLevels(unlockedLevels[2], lockedLevels[2]); //unlock level 3
            UnlockedLevels(unlockedLevels[3], lockedLevels[3]); //unlock level 4
            UnlockedLevels(unlockedLevels[4], lockedLevels[4]); //unlock level 5
            UnlockedLevels(unlockedLevels[5], lockedLevels[5]); //unlock level 6
        }
    }
    #endregion
}
