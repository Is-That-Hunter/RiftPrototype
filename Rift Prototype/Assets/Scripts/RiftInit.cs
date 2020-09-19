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
        // bool RPressed = Input.GetButton("PS4_R3");
        // bool RJustPressed = Input.GetButtonDown("PS4_R3");
        // bool LPressed = Input.GetButton("PS4_L3");
        // bool LJustPressed = Input.GetButtonDown("PS4_L3");
        var basicMovement = GameObject.Find("Jax").GetComponent<BasicMovement>();
        //If the right combo of buttons is pressed
        if (basicMovement.leftStickPressed && basicMovement.rightStickPressed)
        {
            //Call the necessary functions to enable Rift Mode
            Click();
        }
        basicMovement.leftStickPressed = false;
        basicMovement.rightStickPressed = false;
    }

    public void Click()
    {
        ToDoOnDoubleClick.Invoke();
    }
}
