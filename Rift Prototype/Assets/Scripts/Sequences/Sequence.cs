using System;
[System.Serializable]
public class Sequence 
{
    public int currTid;
    public string name;
    public Trigger[] triggers;
}
[System.Serializable]
public class Trigger
{
    public int tid;
    //What state the player needs to be in to trigger
    //dialogue, inventory, player
    public string triggerType;
    public TriggerInfo triggerInfo;
    public TriggerAction triggerAction;
}
[System.Serializable]
public class TriggerInfo
{
    public bool onLeave;
    public bool onEnter;
    public bool onFinish;
    public bool onStart;
    public string onAction;
    public int pid;

    public TriggerInfo(bool _onLeave = false, bool _onEnter = false, bool _onFinish = false, bool _onStart = false, string _onAction = "", int _pid = -1) {
        onLeave = _onLeave;
        onEnter = _onEnter;
        onFinish = _onFinish;
        onStart = _onStart;
        onAction = _onAction;
        pid = _pid;
    }
}
[System.Serializable]
public class TriggerAction
{
    //Defines what to do
    //dialogue, zoom, pan, changeSeq
    public string type;
    public string sequence;
    public int tid;
    //For opening dialogue
    public int pid; 
    public string tree;
    //Zoom in Obj
    public string targetObj;
}