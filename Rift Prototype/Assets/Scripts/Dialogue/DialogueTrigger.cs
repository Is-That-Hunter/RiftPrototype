using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Player to detect Item collisions

public class DialogueTrigger : MonoBehaviour
{
    public GameObject global_variables;
    
    void Start() 
    {
        global_variables = this.gameObject.transform.parent.GetComponent<BasicMovement>().global_variables;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Dialogue")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            global_variables.GetComponent<GlobalScript>().Overlay.GetComponent<Overlay>().changePrompt("Press 'E' To Talk to Guards");
            global_variables.GetComponent<GlobalScript>().Overlay.GetComponent<Overlay>().changePromptActive(true);
            global_variables.GetComponent<TwineParser>().inArea = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Dialogue")
        {
            global_variables.GetComponent<GlobalScript>().Overlay.GetComponent<Overlay>().changePromptActive(false);
            global_variables.GetComponent<TwineParser>().inArea = false;
        }
    }
}
