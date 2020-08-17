using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateMachine : MonoBehaviour
{
    public string state;
    bool DPadDown;
    bool DPadUp;
    bool DPadRight;
    bool DPadLeft;
    bool leftTrigger;

    // Start is called before the first frame update
    void Start()
    {
        state = "Playing";
        bool DPadDown = true;
        bool DPadUp = true;
        bool DPadRight = true;
        bool DPadLeft = true;
        bool leftTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

        //This is hierarchically made to prefer certain buttons. Check w/ Hunter if there's an issue here.
        if(Input.GetAxis("PS4_DPadVertical") == 0)
        {
            DPadDown = false;
            DPadUp = false;
        }
        if (Input.GetAxis("PS4_DPadHorizontal") == 0)
        {
            DPadRight = false;
            DPadLeft = false;
        }
        if(Input.GetAxis("PS4_L2") <= 0)
        {
            leftTrigger = false;
        }

        if (Input.GetAxis("PS4_DPadVertical") < 0 && DPadDown == false)
        {
            changeState("Crafting");
            DPadDown = true;
        }
        else if (Input.GetAxis("PS4_DPadHorizontal") > 0 && DPadRight == false)
        {
            changeState("Inventory");
            DPadRight = true;
        }
        else if (Input.GetAxis("PS4_L2") > 0 && leftTrigger == false)
        {
            changeState("Platform Creation");
            leftTrigger = true;
        }
        else if (Input.GetAxis("PS4_DPadHorizontal") < 0 && DPadLeft == false)
        {
            changeState("Clues");
            DPadLeft = true;
        }
    }

    void changeState(string changeTo)
    {
        if(state == changeTo)
        {
            state = "Playing";
        }
        else
        {
            state = changeTo;
        }

        Debug.Log("state is " + state);
    }
}
