using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A storage and attatchable object for Item 2D UI sprites
//This script is an Attribute of the Global Game object,
//And should be in all scenes

public class ItemAssets : MonoBehaviour
{
    
    public static ItemAssets Instance
    {
        get; private set;
    }

    //Every instance is its own separate object, because it doesn't change
    private void Awake()
    {
        Instance = this;
    }

    //All sprites are kept as variables and assigned
    //In the Unity editor
    public Sprite rockSprite;

    public Sprite batterySprite;

    public Sprite metalSprite;

    public Sprite flashlightSprite;

}
