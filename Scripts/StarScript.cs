using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    LevelManager theLM;

    private void Start()
    {
        theLM = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0));
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
        Destroy(this.gameObject);
    }
}
