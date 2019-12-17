using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    int levelNum;

    public GameObject[] unlockedLevels;
    public GameObject[] lockedLevels;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Level Unlocked", levelNum); //get the number of levels that are unlocked
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevels();
    }

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
            UnlockedLevels(unlockedLevels[1], lockedLevels[1]); //unlock level 2
        }

        if (PlayerPrefs.GetInt("Level Unlocked") == 2)
        {
            UnlockedLevels(unlockedLevels[2], lockedLevels[2]); //unlock level 3
        }

        if (PlayerPrefs.GetInt("Level Unlocked") == 3)
        {
            UnlockedLevels(unlockedLevels[3], lockedLevels[3]); //unlock level 4
        }

        if (PlayerPrefs.GetInt("Level Unlocked") == 4)
        {
            UnlockedLevels(unlockedLevels[4], lockedLevels[4]); //unlock level 5
        }

        if (PlayerPrefs.GetInt("Level Unlocked") == 5)
        {
            UnlockedLevels(unlockedLevels[5], lockedLevels[5]); //unlock level 6
        }
    }
}
