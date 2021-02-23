using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;

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
    public GameObject overlay;
    public Stack<State> stateStack = new Stack<State>();

    // Start is called before the first frame update
    void Start()
    {
        states.Add(new State("Player", player));
        states.Add(new State("Inventory", inventory));
        states.Add(new State("Dialogue", dialogue));
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
        if(_newState == stateStack.Peek())
            return;
        stateStack.Peek().changeActive(false, disableObj);
        _newState.changeActive(true);
        stateStack.Push(_newState);
        overlay.SetActive(overlayActive);

    }
    public void popState(bool disableObj = true, bool overlayActive = true)
    {
        State x = stateStack.Pop();
        x.changeActive(false, disableObj);
        stateStack.Peek().changeActive(true);
        overlay.SetActive(overlayActive);
    }
    public State peekState()
    {
        return stateStack.Peek();
    }
}

