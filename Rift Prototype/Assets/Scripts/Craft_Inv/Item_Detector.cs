using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Player to detect Item collisions

public class Item_Detector : MonoBehaviour
{
    public Collision currentCol = null;

    // Update is called once per frame
    void Update()
    {
        
    }
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Item")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Item Detected");
            currentCol = collision;
        }
    }

    /*void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Debug.Log("Item Detected");
            currentCol = other;
        }
    }*/

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Item")
        {
            Debug.Log("Left Item Collider Area");
            currentCol = null;
        }
    }
}
