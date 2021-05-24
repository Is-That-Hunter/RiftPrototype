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
    public StateInterface script;
    public void changeActive(bool active, bool disableObj = false)
    {
        script.isActive = active;
        script.changeActive(active);
        script.enabled = active;
        script.gameObject.SetActive(true);
        if(disableObj) {
            script.gameObject.SetActive(false);
        }
    }
}
public class StateMachine : MonoBehaviour
{
    public List<State> states;
    public Overlay overlay;
    public GlobalData globalScript;
    public Stack<State> stateStack = new Stack<State>();

    // Start is called before the first frame update
    void Start()
    {
        globalScript = gameObject.GetComponent<GlobalData>();
        states = globalScript.states;
        overlay = globalScript.overlay;
        /*
        states.Add(new State("Player", player));
        states.Add(new State("Inventory", inventory));
        states.Add(new State("Dialogue", dialogue));
        states.Add(new State("Pause", pause));
        states.Add(new State("Report", report));
        */
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
        overlay.changePromptActive(overlayActive);
        handleAction(newState, onEnter: true);
        
        string prnt = "";
        foreach(State x in stateStack.ToArray())
        {
            prnt += x.stateName + "\n";
        }
        Debug.Log(prnt);

        if(newState == "Report" || newState == "Inventory" || newState == "Pause") {
            Debug.Log("Pausing Time");
            Time.timeScale = 0;
        }
    }
    public void popState(bool disableObj = true, bool overlayActive = false, int pid = -1, string tree = "")
    {
        State x = stateStack.Pop();
        x.changeActive(false, disableObj);
        stateStack.Peek().changeActive(true);
        overlay.changePromptActive(overlayActive);
        if(x.stateName == "Dialogue") {
            handleAction(x.stateName, onLeave: true, pid: pid, tree: tree);
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
        if(stateStack.Peek().stateName == "Player")
        {
            Time.timeScale = 1;
        }
    }
    public void disableTopState()
    {
        State x = stateStack.Peek();
        x.changeActive(false, true);
    }
    public void enableTopState()
    {
        State x = stateStack.Peek();
        x.changeActive(true);
    }
    public State peekState()
    {
        return stateStack.Peek();
    }
    public void handleAction(string triggerType, bool onLeave = false, bool onEnter = false, string onAction = "", int pid = -1, string tree = "")
    {
        TriggerInfo trigInfo = new TriggerInfo(onLeave,onEnter,onAction,pid, tree);
        globalScript.sequenceHandler.handleAction(trigInfo, triggerType);
    }
}

