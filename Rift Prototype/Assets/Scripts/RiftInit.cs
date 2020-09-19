using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RiftInit : MonoBehaviour
{
    public UnityEvent ToDoOnDoubleClick;
    public UnityEvent ToDoOnTriangle;

    // Update is called once per frame
    void Update()
    {
        bool RPressed = Input.GetButton("PS4_R3");
        bool RJustPressed = Input.GetButtonDown("PS4_R3");
        bool LPressed = Input.GetButton("PS4_L3");
        bool LJustPressed = Input.GetButtonDown("PS4_L3");

        //If the right combo of buttons is pressed
        if (((RPressed && LJustPressed) || (LPressed && RJustPressed)) || Input.GetButtonDown("PS4_Touch"))
        {
            //Call the necessary functions to enable Rift Mode
            Click();
        }

        if(Input.GetButtonDown("PS4_Triangle"))
        {
            //Call the necessary functions to enable Crafting Menu
            ClickTriangle();
            Debug.Log("Triangle Just Pressed");
        }

    }

    void Click()
    {
        ToDoOnDoubleClick.Invoke();
    }

    void ClickTriangle()
    {
        ToDoOnTriangle.Invoke();
    }
}
