using System;
[System.Serializable]
public class Sequence 
{
    public int currTid;
    public string name;
    public bool order;
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
    public string sequenceName;
    public bool inuse;
    public bool checkTriggerInfo(TriggerInfo other, string otherType)
    {
        TriggerInfo info = this.triggerInfo;
        return(
            this.triggerType == otherType &&
            (
                other.onAction.Contains(info.onAction) ||
                ((info.onAction == null | info.onAction == "") && other.onAction == "")
            ) &&
            (
                other.tree == info.tree ||
                ((info.tree == null || info.tree == "") && other.tree == "")
            ) &&
            info.onLeave == other.onLeave &&
            info.onEnter == other.onEnter &&
            info.pid == other.pid
        );
    }
}
[System.Serializable]
public class TriggerInfo
{
    public bool onLeave;
    public bool onEnter;
    public string onAction;
    public int pid;
    public string tree;
    public bool once;
    public bool done;

    public TriggerInfo(bool _onLeave = false, bool _onEnter = false, string _onAction = "", int _pid = -1, string _tree = "") {
        onLeave = _onLeave;
        onEnter = _onEnter;
        onAction = _onAction;
        pid = _pid;
        tree = _tree;
    }
}
[System.Serializable]
public class TriggerAction
{
    //Defines what to do
    //dialogue, zoom, pan, changeSeq
    public string type;
    public string addSeq;
    public string removeSeq;
    public int tid;
    public int changetid;
    //For opening dialogue
    public int pid; 
    public string tree;
    //Zoom in Obj
    public string targetObj;
    //Item to give to player
    public string itemName;
    public string itemState;
    //Scene to change to
    public string scene;
    public string[] scenes;
    public int posX;
    public int posY;
    public int posZ;
    public bool playerMode;
}