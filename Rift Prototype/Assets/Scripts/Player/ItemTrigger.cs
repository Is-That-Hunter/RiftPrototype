using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Attach to Player to detect Item collisions

public class ItemTrigger : MonoBehaviour
{
    public Collider currentCol = null;
    public ItemTag currentItem = null;
    public bool reportBoo = false;
    private GlobalData globalData;
    
    void Start()
    {
        globalData = this.gameObject.transform.parent.GetComponent<BasicMovement>().globalData;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            currentItem = collision.gameObject.GetComponent<ItemTag>();

            /*if(new []{"Created", "Filled", "Shot", "Ghost", "ToBeDestroyed", "Destroyed"}.Contains(currentItem.itemState))
            {
                foreach(ItemName name in currentItem.items)
                {
                    string action = "Enter "+ currentItem.itemState+" " + name;
                    globalData.GetComponent<StateMachine>().handleAction("Player", onAction: action);
                }
            }*/
        }
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerStay(Collider collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Item")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            currentItem = collision.gameObject.GetComponent<ItemTag>();
            currentItem.setIndicator(true);

            if(new []{"Created", "Filled", "Shot", "ToBeDestroyed"}.Contains(currentItem.itemState))
            {
                if(currentItem.items.Count() == 1)
                {
                    globalData.overlay.changePrompt("Press 'E' to use " + currentItem.items[0]);
                    globalData.overlay.changePromptActive(true);
                } 
                else if(currentItem.items.Count() >= 0)
                {
                    Debug.Log("Created, Filled, Shot, ToBeDestroyed, with multiple Names");
                    globalData.overlay.changePrompt("Press 'E' to use " + currentItem.items[0]);
                    globalData.overlay.changePromptActive(true);
                }
            } 
            else if(new []{"Ghost", "Destroyed"}.Contains(currentItem.itemState))
            {
                if(currentItem.itemState == "Ghost")
                {
                    if(currentItem.items.Count() == 1)
                    {
                        globalData.overlay.changePrompt("Press 'E' to interact with " + currentItem.items[0] + " Ghost.");
                    } else
                        globalData.overlay.changePrompt("Press 'E' to interact with Ghosts");
                    globalData.overlay.changePromptActive(true);
                }
            }
            else
            {
                //Set Overlay
                if(!currentItem.destroyed)
                {
                    if(currentItem.items.Count() == 1)
                    {
                        globalData.overlay.changePrompt("Press 'E' to pickup " + currentItem.items[0]);
                    } 
                    else
                    {
                        string str = "";
                        foreach(ItemName name in currentItem.items)
                        {
                            str += name.itemName + ", ";
                        }
                        globalData.overlay.changePrompt("Press 'E' to pickup " + str);
                    }
                    globalData.overlay.changePromptActive(true);
                }
                
            }
            currentCol = collision;
        } 
        else if(collision.gameObject.tag == "Report")
        {
            reportBoo = true;
            string name = collision.gameObject.name;
            string report = "";
            switch (name)
            {
                case "PoliceReport":
                    report = "Police Report";
                    break;
                case "GoldbergSafetyReport":
                    report = "Goldberg Safety Report";
                    break;
                case "ForemansReport":
                    report = "Foreman's Report";
                    break;
            }
            string itemPrompt = "Press 'E' to view " + report;
            globalData.overlay.changePromptActive(true);
            globalData.overlay.changePrompt(itemPrompt);
            currentCol = collision;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            collision.gameObject.GetComponent<ItemTag>().setIndicator(false);

            globalData.overlay.changePromptActive(false);
            currentCol = null;
            currentItem = null;
        } else if(collision.gameObject.tag == "Report")
        {
            globalData.overlay.changePromptActive(false);
            reportBoo = false;
            currentCol = null;
        }
    }
}
