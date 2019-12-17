using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour
{
    LevelManager theLM;

    private void Start()
    {
        theLM = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            WinGame();
           // Debug.Log("Player has won game");
        }
    }

    public void WinGame()
    {
        theLM.WinGame();
    }
}
