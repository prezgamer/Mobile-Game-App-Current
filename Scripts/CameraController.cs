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
        }
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
