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

    Vector3 startPos, endPos;
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
        /*Vector3 position = endPos.position;
        Vector3 startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 newPos = position - startPos;

        //this is working!!!
        /*float yPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        Debug.Log(yPos);*/

        PlayerMovement();

        CheckMouseDrag();
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

    //this check the mouse is dragging in what direction
    void CheckMouseDrag()
    {
        //when mouse button is pressed down
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //when mouse button is pressed up
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector3 dist = endPos - startPos; //find the dist between end and start positions

        Debug.Log("Mouse Position: " + dist);
    }
}
