using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System.IO;

//Attached to a Global Constant object
//Meant to make constant instances of variables
//variable examples include Inventory, and Databases
//Ensures constant data remains constant among scenes

public class GlobalScript : MonoBehaviour
{
    
    public Inventory inventory;
    public ItemDatabase itemDatabase;
    public CraftDatabase CraftDatabase;
    public string itemsJson;
    public Item[] items;
    //private UI_Inventory ui_Inventory;
    public UIInventory ui_Inventory;
    public GameObject Overlay;

    //Uses Start to let the other scripts load with Awake functions
    private void Start()
    {
        inventory = new Inventory();
        FromJson();

        //This is for test purposes due to current lack of State Switcher
        //This code can be used in the switch to the Inv/Craft State
        ui_Inventory.SetInventory(inventory);
    }
    void FromJson() 
    {
        string itemsString = Resources.Load<TextAsset>("JSON/"+itemsJson).text;
        Items _items = JsonUtility.FromJson<Items>(itemsString);
        items= _items.items;
        itemDatabase = new ItemDatabase(items);
        CraftDatabase = new CraftDatabase(items.Where(item => item.craftable == true).ToArray());
        inventory.AddItem(itemDatabase.FindItem("Coffee Cup (empty)"));
        inventory.AddItem(itemDatabase.FindItem("Blueprints"));
        inventory.AddItem(itemDatabase.FindItem("Pen"));
    }
}
