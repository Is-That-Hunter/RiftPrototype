using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a custom object class to keep track of the items in the game

public class Item
{

    //Each item has a Name, a Size, a Type, and a Material
    //I used enumerations in hopes of minimizing possible errors

    //This is every name of every item in the game
    public enum ItemName
    {
        Battery,
        SmallMetal,
        Rock,
        Flashlight,
    }

    //All available sizes of items
    public enum ItemSize
    {
        Small,
        Medium,
        Large
    }

    //All available types of items
    public enum ItemType
    {
        Electric,
		Corrosive,
		Sharp,
		Shiny, 
		Explosive,
		Dull,
    }

    //All available item materials
    public enum ItemMaterial
    {
        Wood,
		Metal,
		Plastic, 
		Wool,
		Fabric,
    }

    //Every Item object is made up of 4 variables
    //Its name, its size, its type, and its material
    public ItemName name;
    public ItemSize size;
    public ItemType type;
    public ItemMaterial material;


    //The object can make a request to get the associated
    //2D UI Sprite associated with it
    //These sprites are stored in the ItemAssets script
    public Sprite GetSprite()
    {
        switch (name)
        {
            default:

            case ItemName.Battery:    return ItemAssets.Instance.batterySprite;

            case ItemName.Rock:       return ItemAssets.Instance.rockSprite;

            case ItemName.SmallMetal: return ItemAssets.Instance.metalSprite;

            case ItemName.Flashlight: return ItemAssets.Instance.flashlightSprite;
        }
    }
}
