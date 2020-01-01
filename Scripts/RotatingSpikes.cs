using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpikes : MonoBehaviour
{
    public float rotatingSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotatingSpeed));
    }
}
