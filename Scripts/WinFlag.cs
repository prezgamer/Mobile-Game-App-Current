using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    LevelManager theLM;

    LevelSelection levelSelect;
    public int levelToUnlocked;

    private void Start()
    {
        theLM = FindObjectOfType<LevelManager>();
        levelSelect = FindObjectOfType<LevelSelection>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!theLM.gameIsLost)
            {
                WinGame();
            }
        }
    }

    public void WinGame()
    {
        theLM.UpdateWinScreen();
        theLM.CheckHighscore();

        PlayerPrefs.SetInt("Level Unlocked", levelToUnlocked);
        theLM.WinGame();
    }
}
