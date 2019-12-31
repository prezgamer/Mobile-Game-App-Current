﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindSwipe : MonoBehaviour
{
    #region Variables
    [Header("Touch and Wind Variables")]
    public Slider windPowerIndicator;
    public Vector3 touchPosition;
    public Vector3 startPos, endPos, direction;
    public int windPower;

    [Header("Time Variables")]
    public float startingRechargeTime;
    public float rechargeTime;
    public float timeBefSpawning;
    public float timeBefChangeWind = 5f;

    [Header("Boolean Variables")]
    //public bool canPush;
    public bool isPaused = false;
    public bool losesGame = false;
    #endregion

    private void Start()
    {
        //StopCreatingWind(); //Disable Wind at the start
        StartCoroutine(RunGame());
    }

    #region Wind Create Functions
    //creates a ribbon like trail to symbolise the wind direction
    public void CreateWind()
    {
        GetComponent<TrailRenderer>().emitting = true;

        touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        this.transform.position = new Vector3(touchPosition.x, touchPosition.y, 0);
        rechargeTime = startingRechargeTime; //this resets the time

        windPower -= 1;
    }
    #endregion

    #region Player Wind Controls Function
    void WindControls()
    {
        //only enable when there is 1 finger on screen
        if (Input.touchCount == 1)
        {
            //if mouse button is held down or player has place finger on screen, also if canPush is true
            if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)) && losesGame == false)
            {
                CreateWind(); //just creates a ribbon of the trail renderer
            }
            else
            {
                //recharge wind
                RechargeWindPower();
            }
        } else
        {
            RechargeWindPower();
        }

    }
    #endregion

    #region Wind Power Check Functions
    void CheckWindPower()
    {
        if (windPower <= 0)
        {
            windPower = 0;
            //canPush = false;
        }
        else if (windPower > 100)
        {
            windPower = 100;
        }
    }

    void RechargeWindPower()
    {
        //check if recharge time is more than 0
        if (rechargeTime > 0) //&& canPush == false)
        {
            //count down recharge time and add wind Power at the process
            rechargeTime -= Time.deltaTime;
            windPower += 1;
        }
    }
    #endregion

    IEnumerator RunGame()
    {
        while(LevelManager.runGame == true)
        {
            windPowerIndicator.value = windPower;

            CheckWindPower(); //check the wind current power, switch if nessasary

            WindControls(); //wind controls

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
