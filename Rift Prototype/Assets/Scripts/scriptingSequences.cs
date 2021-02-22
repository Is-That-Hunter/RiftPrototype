using System;
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
    public string triggerType;
    public triggerInfo triggerInfo;
}
[System.Serializable]
public class triggerInfo
{
    public int tid;
    public int pid;
    public string target1;
    public string target2;
    public bool onLeave;
    public bool onEnter;
    public bool onFinish;
    public string onAction;
}
public class twineParser : MonoBehaviour 
{
    private sequence sceneSequence;
    public string sequenceJson;
    public int currTid;
    public GameObject mainCamera;
    public Global_Script global_variables;
    void Start()
    {
        global_variables = gameObject.GetComponent<Global_Script>();
        FromJson();
    }
    void FromJson() 
    {
        string sequencePath = Resources.Load<TextAsset>("JSON/"+sequenceJson).text;
        sequence sequences = JsonUtility.FromJson<sequence>(sequencePath);
        this.sceneSequence = sequences;
    }
}