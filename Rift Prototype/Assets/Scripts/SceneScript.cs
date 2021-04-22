using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

//Attached to a Global Constant object
//Meant to make constant instances of variables
//variable examples include Inventory, and Databases
//Ensures constant data remains constant among scenes

public class SceneScript : MonoBehaviour
{
    public GameObject globalObj;
    public GameObject player;
    public GlobalScript globalScript;
    public StateMachine stateMachine;
    public TwineParser twineParser;
    public SequenceHandler sequenceHandler;
    public List<string> destroyedMonsters = new List<string>();
    //0: objectName, 1: itemState
    public string[] placeableObjects = {"Ghost", "ToBeDestroyed", "Ghost"};
    public Vector3 playerPosition = Vector3.zero;

    //Uses Start to let the other scripts load with Awake functions
    private void Start()
    {
        globalScript = globalObj.GetComponent<GlobalScript>();
        stateMachine = globalObj.GetComponent<StateMachine>();
        twineParser = gameObject.GetComponent<TwineParser>();
        sequenceHandler = gameObject.GetComponent<SequenceHandler>();
    }

    public void OnSceneLoaded()
    {
        foreach (string monsterName in destroyedMonsters) {
            GameObject monster = GameObject.Find(monsterName);
            if(monster != null) {
                Destroy(monster);
            }
        }
        foreach (string objectVars in placeableObjects) {
            GameObject[] objs = {GameObject.Find("CrossingPlankParent"), GameObject.Find("PadlockParent"), GameObject.Find("CannonParent")};
            if(objs[0] != null && placeableObjects[0] != null) 
            {
                foreach(GameObject obj in objs)
                {
                    ItemTag tag = obj.GetComponentsInChildren<ItemTag>()[0];
                    switch(obj.name)
                    {
                        case "CrossingPlankParent":
                            tag.setState(placeableObjects[0]);
                            break;
                        case "PadlockParent":
                            tag.setState(placeableObjects[1]);
                            break;
                        case "CannonParent":
                            tag.setState(placeableObjects[2]);
                            break;
                    }
                }
            }
        }
    }

    public void saveLoadedObjects()
    {
        GameObject[] objs = {GameObject.Find("CrossingPlankParent"), GameObject.Find("PadlockParent"), GameObject.Find("CannonParent")};
        if(objs[0] != null) 
        {
            foreach(GameObject obj in objs)
            {
                ItemTag tag = obj.GetComponentsInChildren<ItemTag>()[0];
                switch(obj.name)
                {
                    case "CrossingPlankParent":
                        placeableObjects[0] = tag.itemState;
                        break;
                    case "PadlockParent":
                        placeableObjects[1] = tag.itemState;
                        break;
                    case "CannonParent":
                        placeableObjects[2] = tag.itemState;
                        break;
                }
            }
        }
    }
}
