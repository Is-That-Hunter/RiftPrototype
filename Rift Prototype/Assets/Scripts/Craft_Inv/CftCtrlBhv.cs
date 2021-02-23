using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Script for defining controls for Crafting/Inv System
//Attatch to Inv_Craft_Table

public class CftCtrlBhv : StateInterface
{
    //Uses the CraftControls input system
    public MainController controls;

    //Set to the crafting slots in editor
    private GameObject material_Slot;
    private GameObject type_Slot;
    private GameObject size_Slot;
    public StateMachine state_m;
    private UIInventory uiInventory;

    private Transform inventory_Slots;

    //Set to Global_Variable Object
    public GameObject global_Variable_Obj;

    private InventoryItem requested_Material = null;
    private InventoryItem requested_Type = null;
    private InventoryItem requested_Size = null;

    private void Awake()
    {
        Transform[] ts = gameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            if(t.gameObject.name == "Craft_Table")
            {
                material_Slot = t.Find("Material_Slot").GetChild(0).gameObject;
                type_Slot = t.Find("Type_Slot").GetChild(0).gameObject;
                size_Slot = t.Find("Size_Slot").GetChild(0).gameObject;
            }
            if(t.gameObject.name == "Inventory_Table")
            {
                uiInventory = t.gameObject.GetComponent<UIInventory>();
                inventory_Slots = t.Find("Inventory_Slots").gameObject.transform;
            }
        }
        //Each special action is defined, set to a filler variable, and assigned to a function to perform
        //When the button is pressed
        controls = new MainController();

        controls.Inventory_Craft.Craft.performed += craft_Behavior => Craft();
    
        controls.Inventory_Craft.Size_Select.performed += set_Size => Set_Size();

        controls.Inventory_Craft.Material_Select.performed += set_Material => Set_Material();

        controls.Inventory_Craft.Type_Select.performed += set_Type => Set_Type();

        controls.Inventory_Craft.State_Switch.performed += ctx => Switch_State();

    }

    public void Switch_State()
    {
        state_m.popState();
    }

    //Crafts the item if the Type, Material, and Size can result in another Item
    void Craft()
    {
        CraftDatabase craftDatabase = global_Variable_Obj.GetComponent<GlobalScript>().CraftDatabase;
        Inventory inventory = global_Variable_Obj.GetComponent<GlobalScript>().inventory;
        Dictionary<(string, string, string), string> recipe = craftDatabase.GetRecipe();
        ItemDatabase allItems = global_Variable_Obj.GetComponent<GlobalScript>().itemDatabase;

        if (requested_Size != null && requested_Material != null && requested_Type != null)
        {
            Debug.Log(requested_Size.item.itemSize + " " + requested_Type.item.itemType + " " + requested_Material.item.itemMaterial);
            if (recipe.TryGetValue((requested_Size.item.itemSize, requested_Type.item.itemType, requested_Material.item.itemMaterial), out string value))
            {
                // Key was in dictionary; "value" contains corresponding value
                Debug.Log("craft Success: You made " + value);
                inventory.CraftRemoval(requested_Size, requested_Type, requested_Material);
                inventory.AddItem(allItems.FindItem(value));
                requested_Material = null;
                requested_Type = null;
                requested_Size = null;
                type_Slot.GetComponent<Image>().sprite = null;
                size_Slot.GetComponent<Image>().sprite = null;
                material_Slot.GetComponent<Image>().sprite = null;
            }
            else
            {
                // Key wasn't in dictionary; "value" is now 0
                Debug.Log("Craft Fail");
            }
        }
        state_m.handleAction("Inventory", onAction: "Craft");
    }

    //Sets the Item and its Size used for crafting
    void Set_Size()
    {
        ImageItem requester_ImIt = EventSystem.current.currentSelectedGameObject.GetComponent<ImageItem>();
        InventoryItem invItem = requester_ImIt.GetItem();
        //bool craft_Available = requester_ImIt.GetCraftBool();
        if (requested_Size == null)
        {
            requested_Size = invItem;
            RemoveFromSlot(invItem);
            invItem.inCraft = "Size";
        }
        else if (requested_Size == invItem)
        {
            requested_Size = null;
            invItem.inCraft = "";
        }
        else if (requested_Size != invItem)
        {
            requested_Size.inCraft = "";
            requested_Size = invItem;
            RemoveFromSlot(invItem);
            invItem.inCraft = "Size";
        }
        SetImages();
        state_m.handleAction("Inventory", onAction: "Size_Select");
    }

    //Sets the Item and its Material used for crafting
    void Set_Material()
    {
        ImageItem requester_ImIt = EventSystem.current.currentSelectedGameObject.GetComponent<ImageItem>();
        InventoryItem invItem = requester_ImIt.GetItem();
        if (requested_Material == null)
        {
            requested_Material = invItem;
            RemoveFromSlot(invItem);
            invItem.inCraft = "Material";
        }
        else if(requested_Material == invItem)
        {
            requested_Material = null;
            invItem.inCraft = "";
        }
        else if (requested_Material != invItem)
        {
            requested_Material.inCraft = "";
            requested_Material = invItem;
            RemoveFromSlot(invItem);
            invItem.inCraft = "Material";
        }
        SetImages();
        state_m.handleAction("Inventory", onAction: "Material_Select");
    }

    //Sets the Item and its Type used for crafting
    void Set_Type()
    {
        ImageItem requester_ImIt = EventSystem.current.currentSelectedGameObject.GetComponent<ImageItem>();
        InventoryItem invItem = requester_ImIt.GetItem();
        if (requested_Type == null)
        {
            requested_Type = invItem;
            RemoveFromSlot(invItem);
            invItem.inCraft = "Type";
        }
        else if (requested_Type == invItem)
        {
            requested_Type = null;
            invItem.inCraft = "";
        }
        else if (requested_Type != invItem)
        {
            requested_Type.inCraft = "";
            requested_Type = invItem;
            RemoveFromSlot(invItem);
            invItem.inCraft = "Type";
        }
        SetImages();
        state_m.handleAction("Inventory", onAction: "Type_Select");
    }

    void RemoveFromSlot(InventoryItem invItem) 
    {
        switch(invItem.inCraft)
        {
            case "Size":
                requested_Size = null;
                break;
            case "Material":
                requested_Material = null;
                break;
            case "Type":
                requested_Type = null;
                break;
        }
    }

    void SetImages()
    {
        if(requested_Size != null)
            size_Slot.GetComponent<Image>().sprite = requested_Size.item.GetSprite();
        else
            size_Slot.GetComponent<Image>().sprite = null;
        if(requested_Material != null)
            material_Slot.GetComponent<Image>().sprite = requested_Material.item.GetSprite();
        else
            material_Slot.GetComponent<Image>().sprite = null;
        if(requested_Type != null)
            type_Slot.GetComponent<Image>().sprite = requested_Type.item.GetSprite();
        else
            type_Slot.GetComponent<Image>().sprite = null;
    }

    //Disables and Enables the controls when Object (Inv_Craft_Table) is Enabled and Disabled
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new MainController();
            // Tell the "gameplay" action map that we want to get told about
            // when actions get triggered.
            //controls.gameplay.SetCallbacks(this);
        }
        if(uiInventory == null)
        {
            uiInventory = gameObject.transform.Find("Inventory_Table").GetComponent<UIInventory>();
        }
        controls.Enable();
        uiInventory.enabled = true;
    }

    private void OnDisable()
    {
        controls.Disable();
        uiInventory.enabled = false;
    }
    public void changeActive(bool _isActive) {
        isActive = _isActive;
        uiInventory.enabled = _isActive;
    }
}
