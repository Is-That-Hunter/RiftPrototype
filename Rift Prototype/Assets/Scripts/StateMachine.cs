using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

//Attach to Global Variable Object
[System.Serializable]
public class State 
{
    public string stateName;
    public GameObject stateObject;
    public StateInterface script;
    
    public State(string _state, GameObject obj)
    {
        stateName = _state;
        stateObject = obj;
        script = obj.GetComponent<StateInterface>();
    }

    public void changeActive(bool active, bool disableObj = false)
    {
        script.isActive = active;
        script.changeActive(active);
        script.enabled = active;
        stateObject.SetActive(true);
        if(disableObj) {
            stateObject.SetActive(false);
        }
    }
}
public class StateMachine : MonoBehaviour
{
    public List<State> states = new List<State>();
    public GameObject player;
    public GameObject inventory;
    public GameObject dialogue;
    public GameObject pause;
    public GameObject overlay;
    public GameObject report;
    public GlobalScript globalScript;
    public Stack<State> stateStack = new Stack<State>();

    // Start is called before the first frame update
    void Start()
    {
        globalScript = gameObject.GetComponent<GlobalScript>();
        states.Add(new State("Player", player));
        states.Add(new State("Inventory", inventory));
        states.Add(new State("Dialogue", dialogue));
        states.Add(new State("Pause", pause));
        states.Add(new State("Report", report));
        stateStack.Push(states.FirstOrDefault(i=>i.stateName == "Player"));
        foreach(State _state in states)
        {
            if(stateStack.Peek() == _state)
                _state.changeActive(true);
            else
                _state.changeActive(false, true);
        }
    }
    public void pushState(string newState, bool disableObj = true, bool overlayActive = false)
    {
        State _newState = states.FirstOrDefault(i=>i.stateName == newState);
        if(stateStack.Contains(_newState))
            return;
        stateStack.Peek().changeActive(false, disableObj);
        _newState.changeActive(true);
        stateStack.Push(_newState);
        overlay.SetActive(overlayActive);
        handleAction(newState, onEnter: true);
        
        string prnt = "";
        foreach(State x in stateStack.ToArray())
        {
            prnt += x.stateName + "\n";
        }
        Debug.Log(prnt);
        
    }
    public void popState(bool disableObj = true, bool overlayActive = true, int pid = -1)
    {
        State x = stateStack.Pop();
        x.changeActive(false, disableObj);
        stateStack.Peek().changeActive(true);
        overlay.SetActive(overlayActive);
        if(x.stateName == "Dialogue") {
            handleAction(x.stateName, onLeave: true, pid: pid);
        }
        else {
            handleAction(x.stateName, onLeave: true);
        }
        
        string prnt = "";
        foreach(State s in stateStack.ToArray())
        {
            prnt += s.stateName + "\n";
        }
        Debug.Log(prnt);
        
    }
    public State peekState()
    {
        return stateStack.Peek();
    }
    public void handleAction(string triggerType, bool onLeave = false, bool onEnter = false, string onAction = "", int pid = -1)
    {
        TriggerInfo trigInfo = new TriggerInfo(onLeave,onEnter,onAction,pid);
        globalScript.sequenceHandler.handleAction(trigInfo, triggerType);
    }
}

