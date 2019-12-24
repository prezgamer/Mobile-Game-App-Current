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

        //CheckMousePos();

        WindControls(); //wind controls

        RechargeWindPower(); //recharge wind
    }

    //creates a ribbon like trail to symbolise the wind direction
    void CreateWind()
    {
        GetComponent<TrailRenderer>().enabled = true;
        touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        this.transform.position = new Vector3(touchPosition.x, touchPosition.y, 0);
        windPower -= 1;
    }

    void StopCreatingWind()
    {
        GetComponent<TrailRenderer>().enabled = false;
    }

    /*void CheckMousePos()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Debug.Log("Position of Mouse is " + Camera.main.ScreenToWorldPoint(mousePos));
    }*/

    void WindControls()
    {
        //check if wind Power is more than 0
        if (windPower > 0 && canPush == true && losesGame == false && isPaused == false)
        {
            if (Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
            {
                CreateWind();
            } 
            //check if wind Power is less than or equal to 0
        }
        else if (windPower <= 0)
        {
            windPower = 0;
            canPush = false;
        }

        if (windPower > 100)
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
