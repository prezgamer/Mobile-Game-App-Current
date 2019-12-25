using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindSwipe : MonoBehaviour
{
    #region Variables
    [Header("Touch and Wind Variables")]
    public Slider windPowerIndicator;
    public Vector3 touchPosition;
    public int windPower;

    public GameObject trail;

    [Header("Time Variables")]
    public float startingRechargeTime;
    public float rechargeTime;
    public float timeBefSpawning;
    public float timeBefChangeWind = 5f;

    [Header("Boolean Variables")]
    public bool canPush;
    public bool isPaused = false;
    public bool losesGame = false;
    #endregion

    private void Start()
    {
        //StopCreatingWind(); //Disable Wind at the start
    }

    // Update is called once per frame
    void Update()
    {
        windPowerIndicator.value = windPower;

        //Debug.Log("Mouse Position: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));

        CheckWindPower(); //check the wind current power, switch if nessasary

        RechargeWindPower(); //recharge wind

        WindControls(); //wind controls
    }

    #region Wind Create Functions
    //creates a ribbon like trail to symbolise the wind direction
    public void CreateWind()
    {
        GameObject newTrail = Instantiate(trail);

        newTrail.GetComponent<TrailRenderer>().emitting = true;
        touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        this.transform.position = new Vector3(touchPosition.x, touchPosition.y, 0);
        windPower -= 1;
    }
    #endregion

    #region Player Wind Controls Function
    void WindControls()
    {
        //if mouse button is held down or player has place finger on screen, also if canPush is true
        if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)) && canPush == true)
        {
            CreateWind();

            //timeBefSpawning -= Time.deltaTime;

            //only if time has gone down to 0, the wind will spawn
            /*if (timeBefSpawning <= 0)
            {
                CreateWind();
            }*/
        }
        //else if mouse button is let go or player have tap off screen or application have cancelled, also if canPush is true
        else if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)) && canPush == true)
        {
            //timeBefSpawning = 0.2f;
            Destroy(trail);
        }
    }
    #endregion

    #region Wind Power Check Functions
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
    #endregion
}
