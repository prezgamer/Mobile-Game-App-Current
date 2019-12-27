using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    Rigidbody2D balloonRb;

    public float speed;
    AudioSource balloonPopSound;
    public GameObject balloonExplosion;
    public bool hasPop = false;
    public float timeBefDissapear;

    LevelManager theLM;

    // Start is called before the first frame update
    void Start()
    {
        balloonRb = GetComponent<Rigidbody2D>(); //get rigidbody2D component

        theLM = FindObjectOfType<LevelManager>();
        balloonPopSound = GameObject.Find("Balloon Pop Sound").GetComponent<AudioSource>();
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
            Pop();
        }
    }

    void Pop()
    {
        hasPop = true;
        LevelManager.PlayAudioSource(balloonPopSound); //play pop sound
        LevelManager.runGame = false;
        Destroy(Instantiate(balloonExplosion, transform.position, Quaternion.identity), timeBefDissapear); //spawn balloon explosion and despawn after 0.5f
        theLM.LoseGame(); //lose game when player pops balloon
        Destroy(this.gameObject);
    }

    /*private void OnDestroy()
    {
        if (theLM.turnOnEffects)
        {
            Destroy(Instantiate(balloonExplosion, transform.position, Quaternion.identity), timeBefDissapear); //spawn balloon explosion and despawn after 0.5f
        } else if (theLM.turnOnEffects == false)
        {
            Debug.Log("do not do anything");
        }
    }*/

}
