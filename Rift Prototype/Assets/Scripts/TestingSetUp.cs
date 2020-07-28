using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSetUp : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;

    private void Awake()
    {
        //Debug.Log(uiInventory);
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }
}
