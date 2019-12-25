using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForces : MonoBehaviour
{
    #region Variables
    Rigidbody2D playerRb;

    WindSwipe theWind;
    Balloon theBalloon;

    public float forceMultiplyer;

    public float startTimeBefChangeWind;
    public float timeBefChangeWind;
    #endregion

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        theBalloon = FindObjectOfType<Balloon>();
        theWind = FindObjectOfType<WindSwipe>();

        timeBefChangeWind = startTimeBefChangeWind; //set time to be starting time
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //check if the balloon has pop, in order for the crate to act normally, rather than having to float in mid air
        if (!theBalloon.hasPop)
        {
            playerRb.velocity = new Vector2(forceMultiplyer * theWind.touchPosition.x, forceMultiplyer * theWind.touchPosition.y);
        }
        else if (theBalloon.hasPop)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y);
        }

        //allow the crate to move the a direction for a few sec before switching back to its normal speed
        if (theWind.touchPosition.x > 0 ||
            theWind.touchPosition.x < 0 ||
            theWind.touchPosition.y > 0 ||
            theWind.touchPosition.y < 0)
        {
            timeBefChangeWind -= Time.deltaTime;
        }

        if (timeBefChangeWind <= 0)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y);
            timeBefChangeWind = startTimeBefChangeWind;
        }
    }
}
