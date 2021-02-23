using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

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
    void Start()
    {
        globalVars = gameObject.GetComponent<GlobalScript>();
        stateMachine = gameObject.GetComponent<StateMachine>();
        twineParser = gameObject.GetComponent<TwineParser>();
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
        if(trigType == trig.triggerType)
        {
            bool activateTrig = trigInfo.onLeave & trig.triggerInfo.onLeave;
            activateTrig = activateTrig || (trigInfo.onEnter & trig.triggerInfo.onEnter);
            activateTrig = activateTrig || (trigInfo.onFinish & trig.triggerInfo.onFinish);
            activateTrig = activateTrig || (trigInfo.onStart & trig.triggerInfo.onStart);
            activateTrig = activateTrig || (trigInfo.onAction != "" & trigInfo.onAction == trig.triggerInfo.onAction);
            if(activateTrig)
                if(trigType == "Dialogue" & trigInfo.pid == trig.triggerInfo.pid)
                {
                    doTrigger(trig.triggerAction);
                    changeCurrTid(trig.triggerAction.tid);
                }
                else if(trigType != "Dialogue")
                {
                    doTrigger(trig.triggerAction);
                    changeCurrTid(trig.triggerAction.tid);
                }
        }
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
    void changeCurrTid(int _tid)
    {
        getCurrSequence().currTid = _tid;
    }
}