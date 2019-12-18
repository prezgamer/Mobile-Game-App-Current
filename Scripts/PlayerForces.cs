using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForces : MonoBehaviour
{
    Rigidbody2D playerRb;

    WindSwipe theWind;
    Balloon theBalloon;

    public float forceMultiplyer;

    public float startTimeBefChangeWind;
    public float timeBefChangeWind;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        theBalloon = FindObjectOfType<Balloon>();
        theWind = FindObjectOfType<WindSwipe>();

        timeBefChangeWind = startTimeBefChangeWind;
    }

    // Update is called once per frame
    void Update()
    {
        //check if the balloon has pop, in order for the crate to act normally, rather than having to float in mid air
        if (!theBalloon.hasPop)
        {
            playerRb.velocity = new Vector2(forceMultiplyer * theWind.touchPosition.x * Time.deltaTime, forceMultiplyer * theWind.touchPosition.y * Time.deltaTime);
        } else if (theBalloon.hasPop)
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

        /*else if (timeBefChangeWind <= 0)
        {
            playerRb.velocity = new Vector2(0, 0);
            timeBefChangeWind = startTimeBefChangeWind;
        }*/

            /*if (timeBefChangeWind <= 5 && theWind.canPush == false)
            {
                playerRb.velocity = new Vector2(theWind.touchPosition.x, theWind.touchPosition.y);
                timeBefChangeWind -= Time.deltaTime;
            } else if (timeBefChangeWind <= 0)
            {
                theWind.canPush = true;
                timeBefChangeWind = 5f;
            }*/
    }
}
