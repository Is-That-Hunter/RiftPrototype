using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

//Script for defining controls for Crafting/Inv System
//Attatch to Inv_Craft_Table

public class CftCtrlBhv : StateInterface
{
    //Uses the CraftControls input system
    public MainController controls;

    //Set to the crafting slots in editor
    private Image material_Slot_Parent_Image;
    private Image material_Slot_Image;
    private Image type_Slot_Parent_Image;
    private Image type_Slot_Image;
    private Image size_Slot_Parent_Image;
    private Image size_Slot_Image;
    private Image preview_Slot_Parent_Image;
    private Image preview_Slot_Image;
    public StateMachine stateMachine;
    private UIInventory uiInventory;

    private Transform inventory_Slots;
    private Transform toolTip;
    public ItemTrigger itemTrigger;
    public GlobalData globalData;

    private InventoryItem requested_Material = null;
    private InventoryItem requested_Type = null;
    private InventoryItem requested_Size = null;

    private void Awake()
    {
        globalData = globalData.GetComponent<GlobalData>();
        //stateMachine = globalData.stateMachine;
        Transform[] ts = gameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            if(t.gameObject.name == "Craft_Table")
            {
                GameObject size_Slot = t.Find("Size_Slot").GetChild(0).gameObject;
                size_Slot_Parent_Image = size_Slot.transform.parent.GetComponent<Image>();
                size_Slot_Image = size_Slot.GetComponent<Image>();
                GameObject material_Slot = t.Find("Material_Slot").GetChild(0).gameObject;
                material_Slot_Parent_Image = material_Slot.transform.parent.GetComponent<Image>();
                material_Slot_Image = material_Slot.GetComponent<Image>();
                GameObject type_Slot = t.Find("Type_Slot").GetChild(0).gameObject;
                type_Slot_Parent_Image = type_Slot.transform.parent.GetComponent<Image>();
                type_Slot_Image = type_Slot.GetComponent<Image>();
                GameObject preview_Slot = t.Find("Preview_Slot").gameObject;
                preview_Slot_Image = preview_Slot.GetComponent<Image>();
            }
            if(t.gameObject.name == "Inventory_Table")
            {
                uiInventory = t.gameObject.GetComponent<UIInventory>();
                inventory_Slots = t.Find("Inventory_Slots").gameObject.transform;
            }
            if(t.gameObject.name == "ToolTip")
            {
                toolTip = t;
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

        controls.Inventory_Craft.Drop.performed += ctx => Drop();

    }

    public void Drop()
    {
        if(uiInventory.CurrentItem == null)
            return;
        InventoryItem item = uiInventory.CurrentItem.GetComponent<ImageItem>().GetItem();
        Inventory inventory = globalData.inventory;
        inventory.RemoveItem(item);
    }

    public void Switch_State()
    {
        stateMachine.popState();
    }

    //Crafts the item if the Type, Material, and Size can result in another Item
    public void Craft()
    {
        CraftDatabase craftDatabase = globalData.craftDatabase;
        Inventory inventory = globalData.inventory;
        Dictionary<(string, string, string), string> recipe = craftDatabase.GetRecipe();
        ItemDatabase allItems = globalData.itemDatabase;
        bool crafted = false;

        if (requested_Size != null && requested_Material != null && requested_Type != null)
        {
            Debug.Log(requested_Size.item.itemSize + " " + requested_Type.item.itemType + " " + requested_Material.item.itemMaterial);
            if (recipe.TryGetValue((requested_Size.item.itemSize, requested_Type.item.itemType, requested_Material.item.itemMaterial), out string value))
            {
                Item craftedItem = allItems.FindItem(value);
                /*if(craftedItem.placeable)
                {
                    if(itemTrigger.currentCol != null && itemTrigger.currentItem.attachedItemName == value
                        && new string[]{"Ghost", "ToBeDestroyed"}.Contains(itemTrigger.currentItem.itemState))
                        //&& !itemTrigger.currentItem.created)
                    {
                        crafted = true;
                        stateMachine.handleAction("Inventory", onAction: "Craft Success PlaceableItem " + value);
                        if(itemTrigger.currentItem.itemState == "Ghost")
                        {
                            if(itemTrigger.currentItem.special)
                            {
                                foreach(GameObject g in itemTrigger.currentItem.OtherObjs)
                                    Destroy(g);
                            }
                            itemTrigger.currentItem.setState("Created");
                        }
                        else
                            itemTrigger.currentItem.setState("Destroyed");
                    }
                    else
                        stateMachine.handleAction("Inventory", onAction: "Craft Fail PlaceableItem " + value);
                }*/
                else
                {
                    crafted = true;
                    inventory.AddItem(allItems.FindItem(value));
                    stateMachine.handleAction("Inventory", onAction: "Craft Success Item " + value);
                }
                if(crafted)
                {
                    // Key was in dictionary; "value" contains corresponding value
                    Debug.Log("Craft Success: You made " + value);
                    inventory.CraftRemoval(requested_Size, requested_Type, requested_Material);
                    requested_Material = null;
                    requested_Type = null;
                    requested_Size = null;
                    SetImages();
                    SetPreview();
                }
            }
            else
            {
                // Key wasn't in dictionary; "value" is now 0
                Debug.Log("Craft Fail");
                stateMachine.handleAction("Inventory", onAction: "Craft Fail");
            }
        }
    }


    //Sets the Item and its Size used for crafting
    public void Set_Size()
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
        SetPreview();
        stateMachine.handleAction("Inventory", onAction: "Size_Select");
    }

    //Sets the Item and its Material used for crafting
    public void Set_Material()
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
        SetPreview();
        stateMachine.handleAction("Inventory", onAction: "Material_Select");
    }

    //Sets the Item and its Type used for crafting
    public void Set_Type()
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
        SetPreview();
        stateMachine.handleAction("Inventory", onAction: "Type_Select");
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
            size_Slot_Image.sprite = requested_Size.item.GetSprite();
        else
            size_Slot_Image.sprite = Resources.Load<Sprite>("Sprites/Items/EmptyItem");
        if(requested_Material != null)
            material_Slot_Image.sprite = requested_Material.item.GetSprite();
        else
            material_Slot_Image.sprite = Resources.Load<Sprite>("Sprites/Items/EmptyItem");
        if(requested_Type != null)
            type_Slot_Image.sprite = requested_Type.item.GetSprite();
        else
            type_Slot_Image.sprite = Resources.Load<Sprite>("Sprites/Items/EmptyItem");
    }

    void SetPreview()
    {
        if(requested_Size == null || requested_Type == null || requested_Material == null)
        {
            preview_Slot_Image.sprite = Resources.Load<Sprite>("Sprites/Items/EmptyItem");
            return;
        }
        CraftDatabase craftDatabase = globalData.craftDatabase;
        Dictionary<(string, string, string), string> recipe = craftDatabase.GetRecipe();
        ItemDatabase allItems = globalData.itemDatabase;
        if(recipe.TryGetValue((requested_Size.item.itemSize, requested_Type.item.itemType, requested_Material.item.itemMaterial), out string value))
        {
            Item craftedItem = allItems.FindItem(value);
            preview_Slot_Image.sprite = craftedItem.GetSprite();
        }
        else
        {
            preview_Slot_Image.sprite = Resources.Load<Sprite>("Sprites/Items/EmptyItem");
        }
    }

    //Disables and Enables the controls when Object (Inv_Craft_Table) is Enabled and Disabled
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new MainController();
        }
        if(uiInventory == null)
        {
            uiInventory = gameObject.transform.Find("Inventory_Table").GetComponent<UIInventory>();
        }
        if(itemTrigger == null)
        {
            itemTrigger = globalData.player.GetComponent<ItemTrigger>();
        }
        controls.Enable();
        uiInventory.enabled = true;
        ChangeRaycast(true);
    }

    private void OnDisable()
    {
        controls.Disable();
        ChangeRaycast(false);
        uiInventory.enabled = false;
    }
    private void ChangeRaycast(bool active)
    {
        material_Slot_Image.raycastTarget = active;
        material_Slot_Parent_Image.raycastTarget = active;
        type_Slot_Image.raycastTarget = active;
        type_Slot_Parent_Image.raycastTarget = active;
        size_Slot_Image.raycastTarget = active;
        size_Slot_Parent_Image.raycastTarget = active;
    }
    new public void changeActive(bool _isActive) {
        isActive = _isActive;
        uiInventory.enabled = _isActive;
    }
}
