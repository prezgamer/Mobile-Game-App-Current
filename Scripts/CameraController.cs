using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 touchPos;

    public bool followPlayer = true;
    public Transform player;
    float smoothTime = 1f;
    float velocity = 0f;
   // public GameObject mainPlayerObj;

    //Vector3 cameraPos;

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            FollowPlayer();
            //SmoothCamera();
        }

        //cameraPos = transform.position;

        /*if (Input.GetMouseButton(1))
        {
            touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            if (touchPos.x < 0)
            {
                //move left
                //cameraPos.x += 130;
                transform.Translate(new Vector3(-1, 0, 0));
            }
           /* else if (touchPos.x > 0)
            {
                //move right
               // cameraPos.x -= 130;
               transform.Translate(new Vector3(-1, 0, 0));
            }
        }*/
    }

    public void FollowPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }

    public void SmoothCamera()
    {
        float newPosX = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocity, smoothTime);
        float newPosY = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocity, smoothTime);

        transform.position = new Vector3(newPosX, newPosY, -10); //follow player 
    }
}
