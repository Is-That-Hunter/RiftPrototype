//Scripts/BasicMovement.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicMovement : StateInterface
{
    MainController controls;
    Vector2 movement;

    public StateMachine state_m;

    public GameObject global_variables;

    public Animator anim;

    //All things considered ground
    public LayerMask groundLayers;

    //Tests where the ground is
    public CapsuleCollider col;

    public float lowJumpMultiplier = 1;
    public float fallMultiplier = 1;

    public bool rightStickPressed;
    public bool leftStickPressed;
    public bool isRunnning;
    public bool isCrouching;
    public bool isDash;
    public bool isJump;
    public bool jumpTriggered = false;
    public Transform cam;
    public float speed = 10.0f;
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
        controls = new MainController();
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        //Collider colliderThing = GetComponent<Collider>();
        jumpNumber = totalJumps;
        distanceToGround = GetComponent<BoxCollider>().bounds.extents.y;
    }

    private void Update()
    {
        if(body.velocity.y < 0)
        {
            body.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if(body.velocity.y > 0 && !isJump && jumpTriggered)
        {
            body.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isGrounded())
        {
            jumpTriggered = false;
            jumpNumber = totalJumps;
        }

        anim.SetBool("isJump", !isGrounded());
        
        //Determine running or walking or crouch
        var currentSpeed = speed;
        if(isRunnning && isGrounded()){
            currentSpeed = speed * 2;
            if(isCrouching){
            }
        }
        if(isCrouching && isGrounded()){
            currentSpeed = speed / 2;
        }
        if(isDash && isGrounded()){
            StartCoroutine(CastDash());
        }
        //Calculate the movement for this frame
        Vector3 velo = Vector3.zero;
        velo.y = body.velocity.y; 
        body.velocity = velo;
        Vector3 input = new Vector3(movement.x, 0, movement.y);
        Vector3 inputT = (input * currentSpeed * Time.deltaTime);
        if (playerMove)
        {
            body.MovePosition(body.position + (input * currentSpeed * Time.deltaTime));
        }
        anim.SetFloat("horizontalMove", inputT.x);
        anim.SetFloat("verticalMove", inputT.z);
        if (inputT.x > 0.01)
        {
            anim.SetBool("wL", true);
            anim.SetBool("wR", false);
        }
        else if(isGrounded() || inputT.x < -0.01)
        {
            anim.SetBool("wR", true);
            anim.SetBool("wL", false);
        }

    }

    //Ground Check
    bool isGrounded() {
        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, distanceToGround + .3f);
        return IsGrounded;
    }

    //Add by Raymond
    //Following functions are related to the input system package
    //Those functions will only be called when input system sending messages
    public void OnJump(){
        Debug.Log(isGrounded());
         if(isGrounded())
            {
            jumpTriggered = true;
            body.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                jumpNumber--;
            }
            else if (jumpNumber > 0)
            {
            body.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
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


    public void Switch_State()
    {
        state_m.pushState("Inventory", false);
    }

    public void Item_Pickup(ItemTrigger itemTrigger)
    {
        GameObject itemObject = itemTrigger.gameObject;
        ItemDatabase ItemDB = global_variables.GetComponent<GlobalScript>().itemDatabase;
        Item itemGrab = null;
        //Get Item Name
        string itemName = itemTrigger.currentItem.attachedItemName;
        if(!itemTrigger.currentItem.destroyed)
        {
            itemGrab = ItemDB.FindItem(itemName);
            state_m.handleAction("Player", onAction: "PickUp " + itemName);

            global_variables.GetComponent<GlobalScript>().inventory.AddItem(itemGrab);
            itemTrigger.currentItem.timeTillRespawn = itemTrigger.currentItem.respawnTime;
            itemTrigger.currentItem.destroyed = true;
            global_variables.GetComponent<GlobalScript>().Overlay.GetComponent<Overlay>().changePromptActive(false);
        }
        
    }

    public void Interact()
    {
        ItemTrigger itemTrigger = gameObject.transform.GetChild(0).GetComponent<ItemTrigger>();
        if (itemTrigger.reportBoo)
        {
            if(itemTrigger.currentCol != null)
            {
                state_m.pushState("Report", false);
            }
        }
        else
        {
            bool inDialogueTrigger = global_variables.GetComponent<GlobalScript>().twineParser.inArea;
            if (inDialogueTrigger) {
                state_m.pushState("Dialogue", false);
            }
            else if(itemTrigger.currentCol != null)
            {
                if (itemTrigger.currentItem.placeable & itemTrigger.currentItem.created)
                    state_m.handleAction("Player", onAction: "Interact PlaceableItem " + itemTrigger.currentItem.attachedItemName);
                else if(!itemTrigger.currentItem.placeable)
                {
                    Item_Pickup(itemTrigger);
                }
            }
        } 
    }

    public void Pause()
    {
        Time.timeScale = 0;
        state_m.pushState("Pause", false);
    }

    public void developCarnival() 
    {
        Debug.Log("Develop Command Carnival");
        state_m.handleAction("Develop", onAction: "C");
    }

    
    void OnEnable(){
        this.gameObject.GetComponent<PlayerInput>().enabled = true;
        controls.PlayerMovement.Enable();
        controls.Develop.Enable();
        controls.PlayerMovement.Running.performed += ctx => isRunnning = true;
        controls.PlayerMovement.Running.performed += ctx => isCrouching = false;
        controls.PlayerMovement.Running.canceled += ctx => isRunnning = false;
        controls.PlayerMovement.Crouching.performed += ctx => isCrouching = true;
        controls.PlayerMovement.Crouching.performed += ctx => isRunnning = false;
        controls.PlayerMovement.Crouching.canceled += ctx => isCrouching = false;
        controls.PlayerMovement.Dash.performed += ctx => isDash = true;
        controls.PlayerMovement.State_Switch.performed += ctxe => Switch_State();
        controls.PlayerMovement.Pause.performed += ctxe => Pause();
        controls.PlayerMovement.Interact.performed += ctxe => Interact();
        controls.PlayerMovement.Jump.performed += ctx => isJump = true;
        controls.PlayerMovement.Jump.canceled += ctx => isJump = false;
        controls.Develop.Carnival.performed += ctx => developCarnival();
    }

    void OnDisable(){
        controls.PlayerMovement.Disable();
        this.gameObject.GetComponent<PlayerInput>().enabled = false;
    }

    //End

}
