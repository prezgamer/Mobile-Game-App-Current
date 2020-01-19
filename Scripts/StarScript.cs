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

    public void RotateStar()
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
        LevelManager.PlayAudioSource(collectSound); //play audioSource Sound
        theLM.starCount += 1;
        Destroy(this.gameObject);
    }
}
