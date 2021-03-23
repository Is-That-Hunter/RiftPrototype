using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ZoomTarget
{
    public string objName;
    public GameObject target;
}
public class SequenceHandler : MonoBehaviour 
{
    public List<Sequence> sceneSequences = new List<Sequence>();
    public string[] sequenceJsons;
    
    public ZoomTarget[] targets;
    public GameObject mainCamera;
    private GlobalScript globalVars;
    private StateMachine stateMachine;
    private TwineParser twineParser;
    public string currentSequence;
    public string universalTriggers;
    public string sceneTriggers;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneScript sceneScript = gameObject.GetComponent<SceneScript>();
        globalVars = sceneScript.globalScript;
        stateMachine = sceneScript.stateMachine;
        twineParser = sceneScript.twineParser;
        foreach(string json in sequenceJsons)
        {
            Sequence seq = FromJson(json);
            this.sceneSequences.Add(seq);
        }
    }
    Sequence FromJson(string json) 
    {
        string sequencePath = Resources.Load<TextAsset>("JSON/"+json).text;
        Sequence seq = JsonUtility.FromJson<Sequence>(sequencePath);
        return seq;
    }
    public void handleAction(TriggerInfo trigInfo, string trigType) 
    {
        Trigger trig = getCurrTrigger();
        Trigger universalTrigger = getTriggerFromSequence(trigInfo, universalTriggers);
        Trigger sceneTrigger = getTriggerFromSequence(trigInfo, sceneTriggers);
        if(trigInfo.onAction != "")
            Debug.Log(trigInfo.onAction);
        bool currTriggerActive = checkSequence(trigInfo);
        if(currTriggerActive) {
            Debug.Log("currTrigger");
            doTrigger(trig.triggerAction);
            changeCurrTid(trig.triggerAction.tid);
        }
        else if(sceneTrigger != null) {
            Debug.Log("sceneTrigger");
            doTrigger(sceneTrigger.triggerAction);
        }
        else if(universalTrigger != null) {
            Debug.Log("sceneTrigger");
            doTrigger(sceneTrigger.triggerAction);
        }
    }
    private bool checkOnAction(string dbOnAction, string onActionTrigger)
    {
        if(onActionTrigger.Contains(dbOnAction))
        {
            return true;
        }
        return false;
    }
    void doTrigger(TriggerAction action)
    {

        switch(action.type)
        {
            case "Dialogue":
                twineParser.currTree = action.tree;
                twineParser.changePid(action.tree,action.pid);
                stateMachine.pushState("Dialogue",false);
                break;
            case "changeSeq":
                currentSequence = action.sequence;
                break;
            case "Zoom":
                mainCamera.GetComponent<CameraController>().focusObject = getZoomObject(action.targetObj).target.transform;
                twineParser.currTree = action.tree;
                twineParser.changePid(action.tree,action.pid);
                stateMachine.pushState("Dialogue",false);
                break;
            case "Item":
                globalVars.inventory.AddItem(globalVars.itemDatabase.FindItem(action.itemName));
                break;
            case "Scene":
                sceneTriggers = action.sceneTriggers;
                SceneManager.LoadScene(action.scene);
                break;
            case "ChangeSequenceTrigger":
                sceneTriggers = action.sceneTriggers;
                break;



        }
    }
    ZoomTarget getZoomObject(string obj)
    {
        ZoomTarget targ = targets.FirstOrDefault(i=>i.objName == obj);
        return targ;
    }
    Sequence getCurrSequence()
    {
        Sequence seq = sceneSequences.FirstOrDefault(i=>i.name == this.currentSequence);
        return seq;
    }
    Trigger getCurrTrigger()
    {
        Sequence seq = this.getCurrSequence();
        if(seq != null)
            return seq.triggers.FirstOrDefault(i=>i.tid == seq.currTid);
        return null;
    }
    bool checkSequence(TriggerInfo trigInfo)
    {
        Trigger currTrig = getCurrTrigger();
        bool isActive = currTrig.triggerInfo.onLeave == trigInfo.onLeave & 
            currTrig.triggerInfo.onEnter == trigInfo.onEnter &
            currTrig.triggerInfo.pid == trigInfo.pid &
            currTrig.triggerInfo.onAction == trigInfo.onAction;
        return isActive;
    }
    Trigger getTriggerFromSequence(TriggerInfo trigInfo, string sequenceName)
    {
        Sequence seq = sceneSequences.FirstOrDefault(i=>i.name == sequenceName);
        Debug.Log(seq);
        Trigger ret = null;
        if(seq != null) 
        {
            ret = seq.triggers
                .Where(i=>i.triggerInfo.onLeave == trigInfo.onLeave)
                .Where(i=>i.triggerInfo.onEnter == trigInfo.onEnter)
                .Where(i=>i.triggerInfo.pid == trigInfo.pid)
                .Where(i=>i.triggerInfo.onAction == trigInfo.onAction)
                .DefaultIfEmpty(null)
                .FirstOrDefault();
        }
        
        return ret;
    }
    void changeCurrTid(int _tid)
    {
        getCurrSequence().currTid = _tid;
    }
}