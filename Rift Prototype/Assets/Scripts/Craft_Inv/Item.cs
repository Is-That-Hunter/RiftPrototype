using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a custom object class to keep track of the items in the game
[System.Serializable]
public class Items 
{
    public Item[] items;
}
[System.Serializable]
public class Item
{
    public string itemName;
    public string itemSize;
    public string itemType;
    public string itemMaterial;
    public string itemDescription;
    public string spriteName;
    public bool craftable;

    public Sprite GetSprite() {
        var sp  = Resources.Load<Sprite>("Sprites/Items/"+spriteName);
        return sp;
    }
    public string GetDesc()
    {
        return itemDescription;
    }

    public string GetAttr()
    {
        string str = "Size: "+itemSize+"\nType: "+itemType+"\nMaterial: "+itemMaterial;
        return str;
    }

}