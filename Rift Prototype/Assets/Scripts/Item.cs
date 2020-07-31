using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemName
    {
        Battery,
        SmallMetal,
        Rock,
        Flashlight,
    }

    public enum ItemSize
    {
        Small,
        Medium,
        Large
    }

    public enum ItemType
    {
        Electric,
		Corrosive,
		Sharp,
		Shiny, 
		Explosive,
		Dull,
    }

    public enum ItemMaterial
    {
        Wood,
		Metal,
		Plastic, 
		Wool,
		Fabric,
    }

    public ItemName name;
    public ItemSize size;
    public ItemType type;
    public ItemMaterial material;

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
