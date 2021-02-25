using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System.IO;

//Attached to a Global Constant object
//Meant to make constant instances of variables
//variable examples include Inventory, and Databases
//Ensures constant data remains constant among scenes

public class SceneScript : MonoBehaviour
{
    public GameObject globalObj;
    public GlobalScript globalScript;
    public StateMachine stateMachine;
    public TwineParser twineParser;
    public SequenceHandler sequenceHandler;

    //Uses Start to let the other scripts load with Awake functions
    private void Start()
    {
        globalScript = globalObj.GetComponent<GlobalScript>();
        stateMachine = globalObj.GetComponent<StateMachine>();
        twineParser = gameObject.GetComponent<TwineParser>();
        sequenceHandler = gameObject.GetComponent<SequenceHandler>();
    }
}
