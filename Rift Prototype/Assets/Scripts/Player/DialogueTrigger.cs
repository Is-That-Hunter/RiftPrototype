using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Player to detect Item collisions

public class DialogueTrigger : MonoBehaviour
{
    private GlobalData globalData;
    private TwineParser twineParser;
    private Overlay overlay;
    
    void Start() 
    {
        this.globalData =this.gameObject.transform.parent.GetComponent<BasicMovement>().globalData;
        this.twineParser = globalData.twineParser;
        this.overlay = globalData.overlay;
    }
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "TriggerDialogue")
        {
            DialogueTag tag = collision.gameObject.GetComponent<DialogueTag>();
            globalData.sequenceHandler.handleAction(new TriggerInfo(false,true,tag.onAction),"Clown");
            if(tag.once)
                Destroy(tag.gameObject);
        }
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerStay(Collider collision)
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
