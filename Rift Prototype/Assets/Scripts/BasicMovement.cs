//Scripts/BasicMovement.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Add by Raymond
//Verson 1.0, Last edited on 9/17/2020
//This script will handle most of the movement and key binding from input system
//which works for both controller and keyboard
public class BasicMovement : StateInterface
{
    //Add by Raymond
    //Inital the input system package
    MainController controls;
    Vector2 movement;
    Vector2 cameraAngle;
    //Booleans for detecting the pressed key at the moment
    //Same as GetKeyDown
    public StateMachine state_m;

    public GameObject global_variables;

    public bool rightStickPressed;
    public bool leftStickPressed;
    public bool isRunnning;
    public bool isCrouching;
    public bool isDash;
    public bool isSliding;
    public bool yInverted;
    public bool xInverted;
    public float rightTriggerValue;
    public float leftTriggerValue;
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
        //freeLook = mainCamera.GetComponent<CinemachineFreeLook>();
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
        //transform.rotation = Quaternion.LookRotation(mainCamera.transform.position);
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
        Vector3 velo = Vector3.zero;
        velo.y = body.velocity.y; 
        body.velocity = velo;
        //Vector3 dPadInput = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxisRaw("PS4_DPadHorizontal"), 0, -Input.GetAxisRaw("PS4_DPadVertical"));
        //Vector3 input = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(movement.x, 0, movement.y);
        Vector3 input = new Vector3(movement.x, 0, movement.y);
        //Player movement in a left right forward back space
        if (playerMove)
        {
            body.MovePosition(body.position + (input * currentSpeed * Time.deltaTime));
        }

    }
    void LateUpdate(){
        //freeLook.m_XAxis.Value = Quaternion.Lerp(Quaternion.Euler(0, freeLook.m_XAxis.Value, 0), Quaternion.Euler(0, cameraAngle.x * cameraSpeed, 0), 5 * Time.deltaTime).eulerAngles.y;
        //freeLook.m_YAxis.Value -= cameraAngle.y * 2f * Time.deltaTime;
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

    public void Switch_State()
    {
        state_m.pushState("Inventory", false);
    }

    public void Item_Pickup(Collider itemCollider)
    {
        //Collider itemCollider = gameObject.transform.GetChild(0).GetComponent<ItemDetector>().currentCol;
        if(itemCollider != null)
        {
            ItemDatabase ItemDB = global_variables.GetComponent<GlobalScript>().itemDatabase;
            GameObject itemObject = itemCollider.gameObject;
            Item itemGrab = null;
            if(itemObject.tag != "Item")
            {
                string itemName = itemObject.transform.GetChild(0).GetComponent<ItemTag>().attachedItemName;
                itemGrab = ItemDB.FindItem(itemName);
                state_m.handleAction("Player", onAction: "PickUp " + itemName);
            }
            else
            {
                string itemName = itemObject.GetComponent<ItemTag>().attachedItemName;
                itemGrab = ItemDB.FindItem(itemName);
                state_m.handleAction("Player", onAction: "PickUp " + itemName);
            }
            global_variables.GetComponent<GlobalScript>().inventory.AddItem(itemGrab);
            Destroy(itemObject.gameObject.transform.parent.gameObject);
            gameObject.transform.GetChild(0).GetComponent<ItemDetector>().currentCol = null;
            global_variables.GetComponent<GlobalScript>().Overlay.GetComponent<Overlay>().changePromptActive(false);
        }
    }

    public void Interact()
    {
        Collider itemCollider = gameObject.transform.GetChild(0).GetComponent<ItemDetector>().currentCol;
        bool inDialogueTrigger = global_variables.GetComponent<GlobalScript>().twineParser.inArea;
        if(inDialogueTrigger) {
            state_m.pushState("Dialogue", false);
        }
        else if(itemCollider != null)
        {
            Item_Pickup(itemCollider);
        }
    }

    
    void OnEnable(){
        controls.PlayerMovement.Enable();
        controls.PlayerMovement.Running.performed += ctx => isRunnning = true;
        controls.PlayerMovement.Running.performed += ctx => isCrouching = false;
        controls.PlayerMovement.Running.canceled += ctx => isRunnning = false;
        controls.PlayerMovement.Crouching.performed += ctx => isCrouching = !isCrouching;
        controls.PlayerMovement.Dash.performed += ctx => isDash = true;
        controls.PlayerMovement.State_Switch.performed += ctxe => Switch_State();
        controls.PlayerMovement.Interact.performed += ctxe => Interact();
    }

    void OnDisable(){
        controls.PlayerMovement.Disable();
    }

    //End

}
