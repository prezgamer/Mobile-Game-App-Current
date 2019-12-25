using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMousePosition : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        CheckMousePos();
    }

    void CheckMousePos()
    {
        Vector3 currentPos = this.transform.position;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //store the vector3 variable of the mouse position on the screen

        //check if mouse is downwards
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < currentPos.y)
        {
            Debug.Log("mouse is on bottom of object");
        }

        //check if mouse is upwards
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > currentPos.y)
        {
            Debug.Log("mouse is on top of object");
        }

        //check if mouse is left
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < currentPos.x)
        {
            Debug.Log("mouse is left of object");
        }

        //check if mouse is right
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > currentPos.x)
        {
            Debug.Log("mouse is right of object");
        }
    }
}
