using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    //get balloon to fly up for now
    //balloon should fly up only when no forces are playing on it (maybe 5 sec), this will be place in windswipe script
    Rigidbody2D balloonRb;

    public float speed;
    public GameObject balloonExplosion;
    public bool hasPop = false;

    LevelManager theLM;

    // Start is called before the first frame update
    void Start()
    {
        balloonRb = GetComponent<Rigidbody2D>(); //get rigidbody2D component

        theLM = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        balloonRb.velocity = new Vector2(balloonRb.velocity.x, speed); //fly up for now
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spike")
        {
            hasPop = true;
            theLM.LoseGame(); //lose game when player pops balloon
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        //Instantiate(balloonExplosion, transform.position, Quaternion.identity);
    }
}
