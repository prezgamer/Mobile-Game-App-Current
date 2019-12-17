using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public int levelNum;

    public GameObject[] unlockedLevels;
    public GameObject[] lockedLevels;

    private void Awake()
    {
        WarningsForArrays();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Level Unlocked", levelNum); //get the number of levels that are unlocked
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevels();

        WarningsForArrays();
    }

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
}
