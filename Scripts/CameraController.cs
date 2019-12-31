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

    Vector2 pos1, pos2;
    Vector2 previousDist;
    Vector2 distanceBtwFingers;

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            FollowPlayer();
            ControlCamera();
            CalculateDistance();
        }
    }

    void ControlCamera()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            //if both fingers are on the screen
            if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
            {
                pos1 = touch1.position;
                pos2 = touch2.position;

                distanceBtwFingers = pos1 + pos2; //calculate distance of fingers
            } else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
            {
                //store the positions into pos 1 and 2 respectively
                pos1 = touch1.position;
                pos2 = touch2.position;

                distanceBtwFingers = pos1 + pos2; //calculate distance of fingers
            } else if (touch1.phase == TouchPhase.Ended && touch2.phase == TouchPhase.Ended)
            {
                previousDist = distanceBtwFingers; //set the previous pos when touches have ended
            }
        }
    }

    void CalculateDistance()
    {
        float minSize = 3f;
        float maxSize = 3.5f;

        //check if previous distance magnitute or distance is less than distance magitute
        if (previousDist.magnitude < distanceBtwFingers.magnitude)
        {
            Camera.main.orthographicSize -= 1; //decrease camera size
        } else if (previousDist.magnitude > distanceBtwFingers.magnitude)
        {
            Camera.main.orthographicSize += 1; //increase camera size
        }

        //check if camera size do not exceed its min and max sizes
        if (Camera.main.orthographicSize > maxSize)
        {
            Camera.main.orthographicSize = maxSize;
        } else if (Camera.main.orthographicSize < minSize)
        {
            Camera.main.orthographicSize = minSize;
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
