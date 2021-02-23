/*using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
[System.Serializable]
public class sequence 
{
    public trigger[] triggers;
}
[System.Serializable]
public class trigger
{
    public int tid;
    //What state the player needs to be in to trigger
    //dialogue, inventory, player
    public string triggerType;
    public triggerInfo triggerInfo;
    public triggerAction triggerAction;
}
[System.Serializable]
public class triggerInfo
{
    public bool onLeave;
    public bool onEnter;
    public bool onFinish;
    public string onAction;
    public int pid;
}
[System.Serializable]
public class triggerAction
{
    //Defines what to do
    //dialogue, zoom, pan
    public string type;
    public int tid;
    //For opening dialogue
    public int pid; 
    //Zoom in Obj
    public string targetObj;
}
[System.Serializable]
public class zoomTarget
{
    public string objName;
    public GameObject target;
}
public class sequenceParser : MonoBehaviour 
{
    private sequence sceneSequence;
    public string sequenceJson;
    public int currTid;
    public zoomTarget[] targets;
    public GameObject mainCamera;
    public GlobalScript global_variables;
    public StateMachine stateMachine;
    void Start()
    {
        global_variables = gameObject.GetComponent<GlobalScript>();
        FromJson();
    }
    void FromJson() 
    {
        string sequencePath = Resources.Load<TextAsset>("JSON/"+sequenceJson).text;
        sequence sequences = JsonUtility.FromJson<sequence>(sequencePath);
        this.sceneSequence = sequences;
    }
    void onAction(string action)
    {

    }
    void onLeave(string state, int pid = -1)
    {
        trigger trig = getTrigger(this.currTid);
        if(trig.type == "dialogue" & pid != -1) 
        {
            if(trig.pid == pid)
            {
                doTrigger(trig.triggerAction);
            }
        }
    }
    void onEnter()
    {

    }
    void doTrigger(triggerAction action)
    {
        switch(action.type)
        {
            case "zoom":
                zObj = getZoomObject(action.targetObj);
                this.mainCamera.GetComponent<CameraController>().focusObject = zObj.target.transform;
                break;
            case "dialogue":

                break;
        }
    }
    zoomTarget getZoomObject(string obj)
    {
        foreach(zoomTarget t in targets)
        {
            if(target.objName==obj)
                return t;
        }
    }
    trigger getTrigger(int _tid)
    {
        foreach(trigger t in this.sceneSequence.triggers)
        {
            if(_tid==this.currTid)
                return t;
        }
    }
}*/