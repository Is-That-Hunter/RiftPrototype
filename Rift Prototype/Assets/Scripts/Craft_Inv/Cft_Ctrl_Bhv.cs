using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Script for defining controls for Crafting/Inv System
//Attatch to Inv_Craft_Table

public class Cft_Ctrl_Bhv : MonoBehaviour
{
    //Uses the Craft_Controls input system
    public Craft_Controls controls;

    //Set to the crafting slots in editor
    public GameObject material_Slot;
    public GameObject type_Slot;
    public GameObject size_Slot;

    public Transform inventory_Slots;

    //Set to Global_Variable Object
    public GameObject global_Variable_Obj;

    private Item requested_Material = null;
    private Item requested_Type = null;
    private Item requested_Size = null;

    private void Awake()
    {
        //Each special action is defined, set to a filler variable, and assigned to a function to perform
        //When the button is pressed
        controls = new Craft_Controls();

        controls.Inventory_Craft.Craft.performed += craft_Behavior => Craft();

        controls.Inventory_Craft.Size_Select.performed += set_Size => Set_Size();

        controls.Inventory_Craft.Material_Select.performed += set_Material => Set_Material();

        controls.Inventory_Craft.Type_Select.performed += set_Type => Set_Type();

    }

    //Crafts the item if the Type, Material, and Size can result in another Item
    void Craft()
    {
        CraftDatabase craftDatabase = global_Variable_Obj.GetComponent<Global_Script>().CraftDatabase;
        Inventory inventory = global_Variable_Obj.GetComponent<Global_Script>().inventory;
        Dictionary<(Item.ItemSize, Item.ItemType, Item.ItemMaterial), Item.ItemName> recipe = craftDatabase.GetRecipe();
        ItemDatabase allItems = global_Variable_Obj.GetComponent<Global_Script>().itemDatabase;

        if (requested_Size != null && requested_Material != null && requested_Type != null)
        {
            Debug.Log(requested_Size.size + " " + requested_Type.type + " " + requested_Material.material);
            if (recipe.TryGetValue((requested_Size.size, requested_Type.type, requested_Material.material), out Item.ItemName value))
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
    }

    //Sets the Item and its Size used for crafting
    void Set_Size()
    {
        //Debug.Log("HELLO");
        ImageItem requester_ImIt = EventSystem.current.currentSelectedGameObject.GetComponent<ImageItem>();
        bool craft_Available = requester_ImIt.GetCraftBool();
        if (craft_Available && requested_Size == null)
        {
            requested_Size = requester_ImIt.GetItem();

            size_Slot.GetComponent<Image>().sprite = requested_Size.GetSprite();

            requester_ImIt.SetCraftBool(false);

            requester_ImIt.assigned_Craft = size_Slot;
        }
        else if (requester_ImIt.assigned_Craft == size_Slot)
        {
            requested_Size = null;

            size_Slot.GetComponent<Image>().sprite = null;

            requester_ImIt.SetCraftBool(true);

            requester_ImIt.assigned_Craft = null;
        }
    }

    //Sets the Item and its Material used for crafting
    void Set_Material()
    {
        ImageItem requester_ImIt = EventSystem.current.currentSelectedGameObject.GetComponent<ImageItem>();
        bool craft_Available = requester_ImIt.GetCraftBool();
        if (craft_Available && requested_Material == null)
        {
            requested_Material = requester_ImIt.GetItem();

            material_Slot.GetComponent<Image>().sprite = requested_Material.GetSprite();

            requester_ImIt.SetCraftBool(false);

            requester_ImIt.assigned_Craft = material_Slot;
        }
        else if(requester_ImIt.assigned_Craft == material_Slot)
        {
            requested_Material = null;

            material_Slot.GetComponent<Image>().sprite = null;

            requester_ImIt.SetCraftBool(true);

            requester_ImIt.assigned_Craft = null;
        }
    }

    //Sets the Item and its Type used for crafting
    void Set_Type()
    {
        ImageItem requester_ImIt = EventSystem.current.currentSelectedGameObject.GetComponent<ImageItem>();
        bool craft_Available = requester_ImIt.GetCraftBool();
        if (craft_Available && requested_Type == null)
        {
            requested_Type = requester_ImIt.GetItem();

            type_Slot.GetComponent<Image>().sprite = requested_Type.GetSprite();

            requester_ImIt.SetCraftBool(false);

            requester_ImIt.assigned_Craft = type_Slot;
        }
        else if (requester_ImIt.assigned_Craft == type_Slot)
        {
            requested_Type = null;

            type_Slot.GetComponent<Image>().sprite = null;

            requester_ImIt.SetCraftBool(true);

            requester_ImIt.assigned_Craft = null;
        }
    }

    //Disables and Enables the controls when Object (Inv_Craft_Table) is Enabled and Disabled
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new Craft_Controls();
            // Tell the "gameplay" action map that we want to get told about
            // when actions get triggered.
            //controls.gameplay.SetCallbacks(this);
        }
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
