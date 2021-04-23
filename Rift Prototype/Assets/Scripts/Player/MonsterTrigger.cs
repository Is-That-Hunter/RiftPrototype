using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Player to detect Item collisions

public class MonsterTrigger : MonoBehaviour
{
    private SceneScript scene_variables; 
    
    void Start()
    {
        scene_variables = this.gameObject.transform.parent.GetComponent<BasicMovement>().global_variables.GetComponent<GlobalScript>().sceneScript;
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Monster")
        {
            scene_variables.destroyedMonsters.Add(collision.name);
            TriggerInfo trigInfo = new TriggerInfo(false,false,"Monster",-1,"");
            scene_variables.sequenceHandler.handleAction(trigInfo, "Monster");
        }
        
        else if(collision.gameObject.tag == "MonsterFinish")
        {
            TriggerInfo trigInfo = new TriggerInfo(false,false,"finish",-1,"");
            scene_variables.sequenceHandler.handleAction(trigInfo, "Player");
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
        }
        else if(collision.gameObject.tag == "ResetPos")
        {
            TriggerInfo trigInfo = new TriggerInfo(false,true,"",-1,"");
            scene_variables.sequenceHandler.handleAction(trigInfo, "Scene");
        }
    }
}
