using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RiftInit : MonoBehaviour
{
    public UnityEvent ToDoOnDoubleClick;

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

    }

    void Click()
    {
        ToDoOnDoubleClick.Invoke();
    }
}
