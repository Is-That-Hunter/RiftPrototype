using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Global Variable Object

public class Simple_State_M : MonoBehaviour
{
    public GameObject jax;
    public GameObject inventory;

    public enum State
    {
        Craft,
        Player
    }

    State currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Player;
        jax.GetComponent<BasicMovement>().enabled = true;
        inventory.GetComponent<Cft_Ctrl_Bhv>().enabled = false;
        inventory.SetActive(false);
    }

    // Update is called once per frame
    public void Switch_State()
    {
        //Debug.Log(Input.GetKeyDown("q"));
        //Debug.Log("HELLO");
        if (currentState == State.Player)
        {
            inventory.SetActive(true);
            jax.GetComponent<BasicMovement>().enabled = false;
            inventory.GetComponent<Cft_Ctrl_Bhv>().enabled = true;
            currentState = State.Craft;
        } else if (currentState == State.Craft)
        {
            jax.GetComponent<BasicMovement>().enabled = true;
            inventory.GetComponent<Cft_Ctrl_Bhv>().enabled = false;
            inventory.SetActive(false);
            currentState = State.Player;
        }
    }

    /*public State GetCurrentState()
    {
        return currentState;
    }

    public void updateCurrentState(State newState)
    {
        currentState = newState;
    }*/
}
