using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Transform cam;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //X Z MOVEMENT
        Vector3 camF = cam.forward;
        camF.y = 0;
        camF = camF.normalized;

        Vector3 dPadInput = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxisRaw("PS4_DPadHorizontal"), 0, -Input.GetAxisRaw("PS4_DPadVertical"));
        Vector3 input = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 nothing = new Vector3(0, 0, 0);

        if (dPadInput != nothing) {
            gameObject.GetComponent<CharacterController>().Move(dPadInput * speed * Time.deltaTime);
        }
        else {
            gameObject.GetComponent<CharacterController>().Move(input * speed * Time.deltaTime);
        }
    }
}
