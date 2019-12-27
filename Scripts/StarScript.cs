using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    LevelManager theLM;
    AudioSource collectSound;

    private void Start()
    {
        theLM = FindObjectOfType<LevelManager>();

        collectSound = GameObject.Find("Star Collect Sound").GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 2, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CollectStars();
        }
    }

    public void CollectStars()
    {
        theLM.starCount += 1;
        collectSound.Play();
        Destroy(this.gameObject);
    }
}
