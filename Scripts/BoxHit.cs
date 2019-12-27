using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHit : MonoBehaviour
{
    AudioSource boxHitSound;

    // Start is called before the first frame update
    void Start()
    {
        boxHitSound = GameObject.Find("Box Hit Sound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            LevelManager.PlayAudioSource(boxHitSound);
        }
    }
}
