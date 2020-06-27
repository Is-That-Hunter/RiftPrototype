using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Transform cam;
    public float speed = 10.0f;
    public float jumpHeight = 2.0f;
    private int jumpNumber = 0;
    public int totalJumps = 2;
    public bool playerMove = true;
    private float distanceToGround;
    private Rigidbody body;

    public void LockPlayer()
    {
        playerMove = !playerMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        Collider colliderThing = GetComponent<Collider>();
        jumpNumber = totalJumps;
        distanceToGround = colliderThing.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded())
        {
            jumpNumber = totalJumps;
        }

        Vector3 velo = new Vector3(0, 0, 0);
        velo.y = body.velocity.y; 
        body.velocity = velo;
        Vector3 dPadInput = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxisRaw("PS4_DPadHorizontal"), 0, -Input.GetAxisRaw("PS4_DPadVertical"));
        Vector3 input = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 nothing = new Vector3(0, 0, 0);

        //Player movement in a left right forward back space
        if (playerMove)
        {
            if (dPadInput != nothing)
            {
                body.MovePosition(body.position + (dPadInput * speed * Time.deltaTime));
            }
            else
            {
                body.MovePosition(body.position + (input * speed * Time.deltaTime));
            }
        }

        //reeeaallll basic jump script
        if (Input.GetButtonDown("PS4_X"))
        {
            if(isGrounded())
            {
                Vector3 fuckYou = body.velocity;
                fuckYou.y += jumpHeight;
                body.velocity = fuckYou;
                jumpNumber--;
            }
            else if (jumpNumber > 0)
            {
                Vector3 fuckYou = body.velocity;
                fuckYou.y += jumpHeight;
                body.velocity = fuckYou;
                jumpNumber--;
            }
        }

    }

    //Ground Check
    bool isGrounded() {
        return Physics.Raycast(body.transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
}
