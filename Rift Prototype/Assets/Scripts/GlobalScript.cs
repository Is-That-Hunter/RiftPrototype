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
    public GameObject SceneObj;
    public string itemsJson;
    public Item[] items;
    public UIInventory ui_Inventory;
    public Overlay Overlay;
    public TwineParser twineParser;
    public SequenceHandler sequenceHandler;
    public SceneScript sceneScript;

    //Uses Start to let the other scripts load with Awake functions
    private void Start()
    {
        sceneScript = SceneObj.GetComponent<SceneScript>();
        twineParser = SceneObj.GetComponent<TwineParser>();
        sequenceHandler = SceneObj.GetComponent<SequenceHandler>();
        DontDestroyOnLoad(this.gameObject);
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
        inventory.AddItem(itemDatabase.FindItem("Cannonball"));
        inventory.AddItem(itemDatabase.FindItem("Lockpick"));
        inventory.AddItem(itemDatabase.FindItem("Megaphone"));
        inventory.AddItem(itemDatabase.FindItem("Construction Pipes"));
        inventory.AddItem(itemDatabase.FindItem("Old Tire"));
        inventory.AddItem(itemDatabase.FindItem("Old Tire"));
        
        
    }
}
