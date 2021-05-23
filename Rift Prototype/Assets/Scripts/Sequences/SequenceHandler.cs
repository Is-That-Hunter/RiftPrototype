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

    public bool search() {
        if(target != null)
            return true;
        target = GameObject.Find(objName);
        if(target != null)
            return true;
        return false;
    }
    public ZoomTarget(string objName_)
    {
        objName = objName_;
    }
}
public class SequenceHandler : MonoBehaviour 
{
    public List<Sequence> sceneSequences = new List<Sequence>();
    public string[] sequenceJsons;
    public ZoomTarget[] targets;
    public CameraController mainCamera;
    private GlobalData globalData;
    private StateMachine stateMachine;
    private TwineParser twineParser;
    private Transform playerTransform;
    public List<string> activeSequences;
    public bool initiliazed;
    private Queue<Trigger> triggerQueue;
    public bool working = false;

    void Start()
    {
        triggerQueue = new Queue<Trigger>();
        globalData = gameObject.GetComponent<GlobalData>();
        stateMachine = globalData.stateMachine;
        twineParser = globalData.twineParser;
        mainCamera = globalData.mainCamera;
        playerTransform = globalData.player.transform;
        foreach(string json in sequenceJsons)
        {
            Sequence seq = FromJson(json);
            this.sceneSequences.Add(seq);
        }
        Debug.Log("Sequence Hanlder: Start");
        handleAction(new TriggerInfo(false,true,"",-1), "Scene");
    }
    Sequence FromJson(string json) 
    {
        string sequencePath = Resources.Load<TextAsset>("JSON/"+json).text;
        Sequence seq = JsonUtility.FromJson<Sequence>(sequencePath);
        return seq;
    }
    private void Update() {
        //handle all Triggers in Queue
        //Debug.Log(triggerQueue.Count);
        if(!working)
        {
            if(triggerQueue.Count != 0)
            {
                working = true;
                Trigger doTrig = triggerQueue.Dequeue();
                if(doTrig.triggerAction.type == "Scene" || doTrig.triggerAction.type == "Scenes")
                {
                    if(globalData.sceneLoaded)
                    {
                        globalData.sceneLoaded = false;
                        printTrigger(doTrig);
                        doTrigger(doTrig);
                    }
                    else {
                        working = false;
                    }
                }
                else {
                    printTrigger(doTrig);
                    doTrigger(doTrig);
                }
                
            }
        }
    }
    public void handleAction(TriggerInfo trigInfo, string trigType) 
    {
        printTriggerInfo(trigInfo, trigType);
        foreach(string seqName in activeSequences)
        {
            Sequence seq = sceneSequences.Where(i=>i.name == seqName).First();
            if(seq.order)
            {
                Trigger trig = getCurrTrigFromSequence(seq);
                if(trig != null && trig.checkTriggerInfo(trigInfo, trigType))
                {
                    trig.inuse = true;
                    triggerQueue.Enqueue(trig);
                    Debug.Log("Added Trigger from " + seq.name + " to Trigger Queue");
                }
                //Debug.Log("Added Trigger from " + seq.name + " to Trigger Queue");
            }
            else
            {
                if(EnqueueList(triggerQueue, getTriggersFromSequence(trigInfo, trigType, seq)) != 0)
                {
                    Debug.Log("Added Triggers from " + seq.name + " to Trigger Queue");
                }
            }
        }
    }
    void doTrigger(Trigger trig)
    {
        TriggerAction action = trig.triggerAction;
        if(action.tid != 0)
        {
            Sequence seq = sceneSequences.Where(i=>i.name == trig.sequenceName).First();
            seq.currTid = action.tid;
        }
        if(action.addSeq != null && action.addSeq != "")
        {
            addSequence(action.addSeq);
        }
        if(action.removeSeq != null && action.removeSeq != "")
        {
            activeSequences.Remove(action.removeSeq);
        }
        if(trig.triggerInfo.once && trig.triggerInfo.done)
        {
            working = false;
            trig.inuse = false;
            return;
        }
        switch(action.type)
        {
            case "Dialogue":
                twineParser.currTree = action.tree;
                twineParser.changePid(action.tree,action.pid);
                stateMachine.pushState("Dialogue",false);
                if(action.targetObj != null && action.targetObj != "")
                {
                    mainCamera.focusObj = new ZoomTarget(action.targetObj);
                }
                mainCamera.focus = true;
                break;
            /*case "Zoom":
                mainCamera.GetComponent<CameraController>().focusObject = getZoomObject(action.targetObj).target.transform;
                twineParser.currTree = action.tree;
                twineParser.changePid(action.tree,action.pid);
                stateMachine.pushState("Dialogue",false);
                working = false;
                break;*/
            case "Item":
                globalData.inventory.AddItem(globalData.itemDatabase.FindItem(action.itemName));
                break;
            case "Scene":
                StartCoroutine(globalData.LoadScene(action.scene));
                break;
            case "Scenes":
                for(int i = 0; i < action.scenes.Length; i++)
                {
                    if(action.scenes[i] != "")
                    {
                        string str = action.scenes[i];
                        action.scenes[i] = "";
                        StartCoroutine(globalData.LoadScene(str));
                        break;
                    }
                }
                break;
            case "Teleport":
                playerTransform.GetComponent<BasicMovement>().inMonsterPlat = action.playerMode;
                //Debug.Log(player.GetComponent<BasicMovement>().inMonsterPlat);
                playerTransform.position = new Vector3(action.posX, action.posY, action.posZ);
                break;
            case "Destroy":
                globalData.inventory.RemoveItemByName(action.targetObj);
                globalData.placeableObjects[1] = "Destroyed";
                globalData.LoadCarnivalData();
                break;
            case "Fill":
                globalData.inventory.RemoveItemByName(action.targetObj);
                globalData.placeableObjects[2] = "Filled";
                globalData.LoadCarnivalData();
                break;
            case "SceneLoaded":
                
                break;
            case "ChangeTele":
                Sequence seq = sceneSequences.Where(i=>i.name == trig.sequenceName).First();
                Trigger changeTrig = seq.triggers.Where(i=>i.tid == action.changetid).First();
                changeTrig.triggerAction.posX = (int)globalData.player.transform.position.x;
                changeTrig.triggerAction.posY = (int)globalData.player.transform.position.y + 1;
                changeTrig.triggerAction.posZ = (int)globalData.player.transform.position.z;
                break;
            case "Exit":
                globalData.endGame = 1;
                SceneManager.MoveGameObjectToScene(globalData.gameObject, SceneManager.GetActiveScene());
                StartCoroutine(globalData.LoadScene("Main_Menu"));
                break;
        }
        working = false;
        trig.inuse = false;
        trig.triggerInfo.done = true;
    }
    Trigger getCurrTrigFromSequence(Sequence seq)
    {
        Trigger currTrig = seq.triggers.Where(i => i.tid == seq.currTid).First();
        currTrig.sequenceName = seq.name;
        return currTrig;
    }
    List<Trigger> getTriggersFromSequence(TriggerInfo trigInfo, string trigType, Sequence seq)
    {
        List<Trigger> ret = new List<Trigger>();
        foreach(Trigger seqTrig in seq.triggers)
        {
            if(seqTrig.checkTriggerInfo(trigInfo, trigType))
            {
                seqTrig.sequenceName = seq.name;
                ret.Add(seqTrig);
            } 
        }
        return ret;
    }
    void addSequence(string newSeq)
    {
        if(!activeSequences.Contains(newSeq))
            activeSequences.Add(newSeq);
    }
    void printTrigger(Trigger trig)
    {
        TriggerInfo info = trig.triggerInfo;
        TriggerAction action = trig.triggerAction;
        Debug.Log(
            "Trigger: " + trig.triggerType + "\n" + 
            "Trigger tid: " + trig.tid + "\n" + 
            "TriggerInfo:\n" + 
            "    onLeave: " + info.onLeave + "\n" +
            "    onEnter: " + info.onEnter + "\n" +
            "    onAction: " + info.onAction + "\n" +
            "    pid: " + info.pid + "\n" +
            "    tree: " + info.tree + "\n" +
            "    once: " + info.once + "\n" +
            "    done: " + info.done + "\n" +
            "TriggerAction:\n" + 
            "    type: " + action.type + "\n" +
            "    pid: " + action.pid + "\n" +
            "    tree: " + action.tree + "\n" +
            "    position: ("+action.posX+","+action.posY+","+action.posZ+")\n"
        );
    }
    string printTriggerInfo(TriggerInfo info, string type)
    {
        
        string ret ="Trigger: " + type + "\n" + 
            "TriggerInfo:\n" + 
            "    onLeave: " + info.onLeave + "\n" +
            "    onEnter: " + info.onEnter + "\n" +
            "    onAction: " + info.onAction + "\n" +
            "    pid: " + info.pid + "\n" +
            "    tree: " + info.tree + "\n" +
            "    once: " + info.once + "\n" +
            "    done: " + info.done + "\n";
        return ret;
    }
    int EnqueueList(Queue<Trigger> queue, List<Trigger> enu) {
        if(enu != null)
        {
            foreach (Trigger obj in enu){
                obj.inuse = true;
                queue.Enqueue(obj);
            }
            return enu.Count;
        }
        return 0;
    }
    void printQueue() {
        string prnt = "";
        foreach(Trigger x in triggerQueue.ToArray())
        {
            prnt += printTriggerInfo(x.triggerInfo,x.triggerType) + "\n";
        }
        Debug.Log(prnt);
    }
}
