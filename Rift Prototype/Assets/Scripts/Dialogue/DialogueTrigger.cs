using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Player to detect Item collisions

public class DialogueTrigger : MonoBehaviour
{
    private GlobalScript globalScript;
    private TwineParser twineParser;
    private Overlay overlay;
    
    void Start() 
    {
        GameObject globalObj = this.gameObject.transform.parent.GetComponent<BasicMovement>().global_variables;
        this.globalScript = globalObj.GetComponent<GlobalScript>();
        this.twineParser = globalObj.GetComponent<TwineParser>();
        this.overlay = globalScript.Overlay.GetComponent<Overlay>();
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Dialogue")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            DialogueTag tag = collision.gameObject.GetComponent<DialogueTag>();
            this.overlay.changePrompt(tag.overlayText);
            this.overlay.changePromptActive(true);
            this.twineParser.currTree = tag.treeName;
            this.twineParser.inArea = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Dialogue")
        {
            this.overlay.changePromptActive(false);
            this.twineParser.inArea = false;
        }
    }
}
