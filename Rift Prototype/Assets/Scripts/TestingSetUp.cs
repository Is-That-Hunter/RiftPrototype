using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSetUp : MonoBehaviour
{
    private Inventory inventory;
    private CraftDatabase craftDatabase;
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] CraftBehavior craftBehavior;
    private ItemDatabase allItems;

    private void Awake()
    {
        //Debug.Log(uiInventory);
        inventory = new Inventory();
        craftDatabase = new CraftDatabase();
        allItems = new ItemDatabase();
        uiInventory.SetInventory(inventory);
        craftBehavior.SetRecipe(craftDatabase.GetRecipe());
        craftBehavior.SetInventory(inventory);
        craftBehavior.SetItemDatabase(allItems);
        craftBehavior.Setreset();
    }
}
