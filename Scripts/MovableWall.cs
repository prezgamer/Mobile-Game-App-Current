using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWall : MonoBehaviour
{
    public Transform leftTransform;
    public Transform rightTransform;

    Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        MoveRight(); //move right by default
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= leftTransform.position.x)
        {
            MoveRight();
        }

        if (transform.position.x >= rightTransform.position.x)
        {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
