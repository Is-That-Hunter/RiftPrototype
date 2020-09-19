using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    public GameObject MainCharacter;

    private Dictionary<InventoryItem, int> Inventory;
    private bool Crafting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Crafting)
        {
            //Implement Crafting Menu
        }
    }

    public void StartRunningTheCraftingUI()
    {
        Inventory = MainCharacter.GetComponent<Dictionary<InventoryItem, int>>();
        Crafting = !Crafting;
    }
}
