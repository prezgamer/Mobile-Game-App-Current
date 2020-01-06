using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpikes : MonoBehaviour
{
    public float rotatingSpeed;

    private void Start()
    {
        StartCoroutine(RunGame());
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, rotatingSpeed));
    }

    IEnumerator RunGame()
    {
        while(LevelManager.runGame == true)
        {
            Rotate();

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
