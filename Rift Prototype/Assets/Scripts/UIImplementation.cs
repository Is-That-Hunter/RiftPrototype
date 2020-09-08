using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIImplementation : MonoBehaviour
{
    public GameObject playingState;
    // create a GameObject for each state
	// Ok, hunter, this is the file I want you to modify. 
    private string state;
    /*
    ^^this string will contain the state that we're switching between within UIStateMachine.
	There are five states: "Playing", "Crafting", "Inventory", "Platform Creation", and "Clues".
	If we need another state, implement it first in UIStateMachine, and THEN here. Make sure it works. 
	*/

	private string oldState;
	/*
	This string will contain the state value from the PREVIOUS frame. 
	*/

    // Update is called once per frame
    void Update()
    {
       	state = UIStateMachine.state; //pull the current state from the state machine 
       	if(state != oldState) {ChangeUI(state);} //This should only be called THE EXACT FRAME that the UI change happened.
       	oldState = state; //Make it so ChangeUI isn't called every frame. 
    }

    void ChangeUI(string state) 
    {
    	/*
       	This switch statement needs to contain your work for the UI.
       	Any and all UI changes can be done within this switch statement.
       	*/
       	switch (state) 
       	{
       		case "Playing":
                turnOffAllStates();
                playingState.SetActive(true);
                //indent code and put it here
                Debug.Log("Changing to " + state);
       			break;
       		case "Crafting":
                turnOffAllStates();
                //set the current state to Active
                //indent code and put it here
                Debug.Log("Changing to " + state);
       			break;
       		case "Inventory":
                turnOffAllStates();
                //indent code and put it here
                Debug.Log("Changing to " + state);
       			break;
       		case "Platform Creation":
                turnOffAllStates();
                //indent code and put it here
                Debug.Log("Changing to " + state);
       			break;
       		case "Clues":
                turnOffAllStates();
                //indent code and put it here
                Debug.Log("Changing to " + state);
       			break;
       	}
    }

    void turnOffAllStates()
    {
        playingState.SetActive(false);
        //set all states Active(false)
        //EVERY TIME YOU IMPLEMENT A STATE, BE SURE TO TURN IT OFF HERE
    }

    //throw any extra methods down here.
}
