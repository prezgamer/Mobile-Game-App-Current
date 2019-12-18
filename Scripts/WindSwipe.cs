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
    public bool losesGame = false;

    // Update is called once per frame
    void Update()
    {
        windPowerIndicator.value = windPower;

        WindControls(); //wind controls

        RechargeWindPower(); //recharge wind
    }

    //creates a ribbon like trail to symbolise the wind direction
    void CreateWind()
    {
        touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        this.transform.position = new Vector3(touchPosition.x, touchPosition.y, 0);
        windPower -= 1;
    }

    void WindControls()
    {
        //check if wind Power is more than 0
        if (windPower > 0 && canPush == true && losesGame == false)
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
