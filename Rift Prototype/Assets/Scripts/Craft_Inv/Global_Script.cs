using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attached to a Global Constant object
//Meant to make constant instances of variables
//variable examples include Inventory, and Databases
//Ensures constant data remains constant among scenes

public class Global_Script : MonoBehaviour
{

    public Inventory inventory;
    public ItemDatabase itemDatabase;
    public CraftDatabase CraftDatabase;
    //private UI_Inventory ui_Inventory;
    public UI_Inventory ui_Inventory;

    //Uses Start to let the other scripts load with Awake functions
    private void Start()
    {
        inventory = new Inventory();
        itemDatabase = new ItemDatabase();
        CraftDatabase = new CraftDatabase();

        //This is for test purposes due to current lack of State Switcher
        //This code can be used in the switch to the Inv/Craft State
        ui_Inventory.SetInventory(inventory);
    }
}
