using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedWind : MonoBehaviour
{
    public float yForce;
    public float xForce;

    //place down 500 for the force as it is the most effective number
    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        //once entered, the constant force is applied
        if (otherObj.tag == "Player")
        {
            ApplyConstantForce(otherObj);
        }
    }

    private void OnTriggerStay2D(Collider2D otherObj)
    {
        if (otherObj.tag == "Player")
        {
            UseConstantForce(otherObj);
        }
    }

    private void OnTriggerExit2D(Collider2D otherObj)
    {
        //once exited, the constant force component is destroyed
        if (otherObj.tag == "Player")
        {
            DespawnConstantForce(otherObj);
        }
    }

    void UseConstantForce(Collider2D other)
    {
        ConstantForce2D theCF2D = other.GetComponent<ConstantForce2D>();

        theCF2D.force = new Vector2(xForce, yForce); //set the relative force as stated
    }

    void ApplyConstantForce(Collider2D other)
    {
        bool hasApplied = false;

        //check if the object has applied constant force
        if (!hasApplied)
        {
            other.gameObject.AddComponent<ConstantForce2D>();
            hasApplied = true;
        }

        ConstantForce2D theCF2D = other.GetComponent<ConstantForce2D>();

        theCF2D.force = new Vector2(xForce, yForce); //set the relative force as stated
    }

    void DespawnConstantForce(Collider2D other)
    {
        Destroy(other.gameObject.GetComponent<ConstantForce2D>());
    }
}
