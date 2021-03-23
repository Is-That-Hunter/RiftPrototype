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
    //0: objectName, 1: placed, 2: filled
    public List<string[]> placeableObjects = new List<string[]>();
    public Vector3 playerPosition = Vector3.zero;

    //Uses Start to let the other scripts load with Awake functions
    private void Start()
    {
        globalScript = globalObj.GetComponent<GlobalScript>();
        stateMachine = globalObj.GetComponent<StateMachine>();
        twineParser = gameObject.GetComponent<TwineParser>();
        sequenceHandler = gameObject.GetComponent<SequenceHandler>();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        foreach (string monsterName in destroyedMonsters) {
            GameObject monster = GameObject.Find(monsterName);
            if(monster != null) {
                Destroy(monster);
            }
        }
        foreach (string[] objectVars in placeableObjects) {
            GameObject obj = GameObject.Find(objectVars[0]);
            Transform[] ts = obj.transform.GetComponentsInChildren<Transform>(true);
            foreach (Transform t in ts)
            {
                if(t.gameObject.name == "Collider")
                {
                    //Do Stuff
                }
            }
        }
    }
}
