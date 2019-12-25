using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindSwipe : MonoBehaviour
{
    public Slider windPowerIndicator;

    public Vector3 touchPosition;
    public float timeBefChangeWind = 5f;

    public int windPower;

    public float startingRechargeTime;
    public float rechargeTime;

    public float timeBefSpawning;

    public bool canPush;
    public bool isPaused = false;
    public bool losesGame = false;

    private void Start()
    {
        StopCreatingWind();
    }

    // Update is called once per frame
    void Update()
    {
        windPowerIndicator.value = windPower;

        CheckWindPower(); //check the wind current power, switch if nessasary

        RechargeWindPower(); //recharge wind

        WindControls(); //wind controls

        //RechargeWindPower(); //recharge wind
    }

    //creates a ribbon like trail to symbolise the wind direction
    void CreateWind()
    {
        GetComponent<TrailRenderer>().emitting = true;
        touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        this.transform.position = new Vector3(touchPosition.x, touchPosition.y, 0);
        windPower -= 1;
    }

    void StopCreatingWind()
    {
        GetComponent<TrailRenderer>().emitting = false;
    }

    void WindControls()
    {
        //if mouse button is held down or player has place finger on screen, also if canPush is true
        if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)) && canPush == true)
        {
            timeBefSpawning -= Time.deltaTime;

            //only if time has gone down to 0, the wind will spawn
            if (timeBefSpawning <= 0)
            {
                CreateWind();
            }
        }
        //else if mouse button is let go or player have tap off screen or application have cancelled, also if canPush is true
        else if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)) && canPush == true)
        {
            timeBefSpawning = 0.2f;
            StopCreatingWind();
        }
    }

    void CheckWindPower()
    {
        if (windPower <= 0)
        {
            windPower = 0;
            canPush = false;
        }
        else if (windPower > 100)
        {
            windPower = 100;
        }
    }

    void RechargeWindPower()
    {
        if (rechargeTime > 0 && canPush == false)
        {
            //count down recharge time and add wind Power at the process
            rechargeTime -= Time.deltaTime;
            windPower += 1;
        }
        
        if (rechargeTime <= 0 || windPower >= 100)
        {
            //reset recharge time and set can Push to true
            rechargeTime = startingRechargeTime;
            canPush = true;
        }
    }
}
