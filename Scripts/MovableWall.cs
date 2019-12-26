﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWall : MonoBehaviour
{
    public Transform leftTransform;
    public Transform rightTransform;

    public bool movingHorizontal = true;
    bool hasMoved = false;

    Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingHorizontal == true)
        {
            MovementHorizontal();
        } else if (movingHorizontal == false)
        {
            MovementVertical();
        }
    }

    void MovementHorizontal()
    {
        if (hasMoved == false)
        {
            MovementDirection(speed, 0);
        }

        if (transform.position.x <= leftTransform.position.x)
        {
            //move right
            MovementDirection(speed, 0);
            hasMoved = true;
        }

        if (transform.position.x >= rightTransform.position.x)
        {
            //move left
            MovementDirection(-speed, 0);
            hasMoved = true;
        }
    }

    void MovementVertical()
    {
        if (hasMoved == false)
        {
            MovementDirection(0, speed);
        }

        if (transform.position.y >= leftTransform.position.y)
        {
            //move down
            MovementDirection(0, -speed);
            hasMoved = true;
        }

        if (transform.position.y <= rightTransform.position.y)
        {
            //move up
            MovementDirection(0, speed);
            hasMoved = true;
        }
    }

    void MovementDirection(float xMove, float yMove)
    {
        rb.velocity = new Vector2(xMove, yMove);
    }
}
