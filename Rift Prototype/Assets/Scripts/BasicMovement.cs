using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

//Add by Raymond
//Verson 1.0, Last edited on 9/17/2020
//This script will handle most of the movement and key binding from input system
//which works for both controller and keyboard
public class BasicMovement : MonoBehaviour
{
    //Add by Raymond
    //Inital the input system package
    MainController controls;
    Vector2 movement;
    Vector2 cameraAngle;
    //Booleans for detecting the pressed key at the moment
    //Same as GetKeyDown
    public bool rightStickPressed;
    public bool leftStickPressed;
    public bool isRunnning;
    public bool isCrouching;
    public bool isDash;
    public bool isSliding;
    public float rightTriggerValue;
    public float leftTriggerValue;
    CinemachineFreeLook freeLook;
    public GameObject mainCamera;
    public Transform cam;
    public float speed = 10.0f;
    private float cameraSpeed = 50.0f;
    public float jumpHeight = 0.1f;
    private int jumpNumber = 0;
    public int totalJumps = 2;
    public float dashForce = 50.0f;
    public bool playerMove = true;
    private float distanceToGround;
    private Rigidbody body;

    public void LockPlayer()
    {
        playerMove = !playerMove;
    }

    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        freeLook = mainCamera.GetComponent<CinemachineFreeLook>();
        controls = new MainController();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();
        Collider colliderThing = GetComponent<Collider>();
        jumpNumber = totalJumps;
        distanceToGround = colliderThing.bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isGrounded())
        {
            jumpNumber = totalJumps;
        }
        
        //Determine running or walking or crouch
        var currentSpeed = speed;
        if(isRunnning){
            currentSpeed = speed * 2;
            if(isCrouching){
            }
        }
        if(isCrouching){
            currentSpeed = speed / 2;
        }
        if(isDash){
            StartCoroutine(CastDash());
        }
        //Calculate the movement for this frame
        Vector3 velo = new Vector3(0, 0, 0);
        velo.y = body.velocity.y; 
        body.velocity = velo;
        Vector3 dPadInput = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxisRaw("PS4_DPadHorizontal"), 0, -Input.GetAxisRaw("PS4_DPadVertical"));
        Vector3 input = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(movement.x, 0, movement.y);
        Vector3 nothing = new Vector3(0, 0, 0);
        //Player movement in a left right forward back space
        if (playerMove)
        {
            if (dPadInput != nothing)
            {
                body.MovePosition(body.position + (dPadInput * currentSpeed * Time.deltaTime));
            }
            else
            {
                body.MovePosition(body.position + (input * currentSpeed * Time.deltaTime));
            }
        }

    }
    void LateUpdate(){
        freeLook.m_XAxis.Value = Quaternion.Lerp(Quaternion.Euler(0, freeLook.m_XAxis.Value, 0), Quaternion.Euler(0, cameraAngle.x * cameraSpeed, 0), 5 * Time.deltaTime).eulerAngles.y;
        freeLook.m_YAxis.Value -= cameraAngle.y * 2f * Time.deltaTime;
    }

    //Ground Check
    bool isGrounded() {
        return Physics.Raycast(body.transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    //Add by Raymond
    //Following functions are related to the input system package
    //Those functions will only be called when input system sending messages
    public void OnJump(){
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

    public void OnMove(InputValue value){
        movement = value.Get<Vector2>();
    }

    public void OnRunning(){

    }

    //Add by Guanchen
    //This function will caculate dash if dash button pressed
    IEnumerator CastDash(){
        Vector3 input = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(movement.x, 0, movement.y);
        body.AddForce(input * dashForce, ForceMode.Impulse);
        yield return new WaitForSeconds(0.2f);
        body.velocity = Vector3.zero;
        isDash = false;
    }

    IEnumerator CastSlide(){
        Vector3 input = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(movement.x, 0, movement.y);
        body.MovePosition(body.position  + (input * speed * Time.deltaTime));
        yield return new WaitForSeconds(0.5f);
        isRunnning = false;
    }

    public void OnCameraMove(InputValue value){
        
        cameraAngle = value.Get<Vector2>();
        Debug.Log(cameraAngle);

    }

    public void OnRiftCast(){
        var gamepad = Gamepad.current;
        leftTriggerValue = gamepad.leftTrigger.ReadValue();
        rightTriggerValue = gamepad.rightTrigger.ReadValue();
    }

    
    void OnEnable(){
        controls.PlayerMovement.Enable();
        controls.PlayerMovement.Running.performed += ctx => isRunnning = true;
        controls.PlayerMovement.Running.performed += ctx => isCrouching = false;
        controls.PlayerMovement.Running.canceled += ctx => isRunnning = false;
        controls.PlayerMovement.Crouching.performed += ctx => isCrouching = !isCrouching;
        controls.PlayerMovement.Dash.performed += ctx => isDash = true;
        
    }

    void OnDisable(){
        controls.PlayerMovement.Disable();
    }

    //End

}
