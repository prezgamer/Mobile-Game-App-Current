using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForces : MonoBehaviour
{
    #region Variables
    Rigidbody2D playerRb;

    WindSwipe theWind;
    Balloon theBalloon;

    //bool runGame = true;

    public float forceMultiplyer;

    [Header("Time Variables")]
    public float startTimeBefChangeWind;
    public float timeBefChangeWind;

    [Header("Direction Variables")]
    public Vector3 startPos, endPos, direction;
    #endregion

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        theBalloon = FindObjectOfType<Balloon>();
        theWind = FindObjectOfType<WindSwipe>();

        timeBefChangeWind = startTimeBefChangeWind; //set time to be starting time

        //StartCoroutine(RunGame());
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        StopMoving();
        CalculateMouseDrag();
    }

    void StopMoving()
    {
        //allow the crate to move the a direction for a few sec before switching back to its normal speed
        if (theWind.touchPosition.x > 0 ||
            theWind.touchPosition.x < 0 ||
            theWind.touchPosition.y > 0 ||
            theWind.touchPosition.y < 0)
        {
            timeBefChangeWind -= Time.deltaTime;
        } else if (timeBefChangeWind <= 0)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y);
            timeBefChangeWind = startTimeBefChangeWind;
        }
    }

    public void PlayerMovement()
    {
        //check if the balloon has pop, in order for the crate to act normally, rather than having to float in mid air
        if (!theBalloon.hasPop)
        {
            playerRb.velocity = new Vector2(forceMultiplyer * direction.x, forceMultiplyer * direction.y);
        }
        else if (theBalloon.hasPop)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y);
        }
    }

    //this check the mouse is dragging in what direction
    public void CalculateMouseDrag()
    {
        //only enable when there is 1 finger on screen
        //if (Input.touchCount == 1)
        
            //when mouse button is pressed down
            if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))) //&& theWind.canPush == true)
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            //when mouse button is pressed up
            else if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)))// && theWind.canPush == true)
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }


            direction = endPos - startPos; //find the dist between end and start positions
        
    }

    /*IEnumerator RunGame()
    {
        while (runGame == true)
        {
            PlayerMovement();
            StopMoving();
            CalculateMouseDrag();

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }*/
}
