using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Player to detect Item collisions

public class ItemDetector : MonoBehaviour
{
    public Collider currentCol = null;
    public GameObject global_variables;
    
    void Start()
    {
        global_variables = this.gameObject.transform.parent.GetComponent<BasicMovement>().global_variables;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Item")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Item Detected");
            string itemPrompt = "Press 'E' to pick up " + collision.gameObject.GetComponent<ItemPickupVar>().attachedItemName;
            global_variables.GetComponent<GlobalScript>().Overlay.GetComponent<Overlay>().changePromptActive(true);
            global_variables.GetComponent<GlobalScript>().Overlay.GetComponent<Overlay>().changePrompt(itemPrompt);
            currentCol = collision;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Debug.Log("Left Item Collider Area");
            global_variables.GetComponent<GlobalScript>().Overlay.GetComponent<Overlay>().changePromptActive(false);
            currentCol = null;
        }
    }
}
