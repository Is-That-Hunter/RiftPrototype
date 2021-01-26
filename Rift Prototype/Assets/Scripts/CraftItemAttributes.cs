using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

//This allows the selection of the attributes of each item to be limited within the editor
//Hopefully allowing the future additions of items to be faster and error free
//Based of this code: https://answers.unity.com/questions/1589566/how-to-limit-the-types-shown-at-the-inspector-in-a.html
//can be edited further to limit each type depending on what else is selected if needed, but would require additional code

public class CraftItemAttributes : MonoBehaviour
{
    public string name;
    public ItemSize size;
    public ItemType type;
    public ItemMaterial material;

    public enum ItemSize { small, medium, large }
    public enum ItemType { electric, corrosive, sharp, shiny, explosive, dull }
    public enum ItemMaterial { wood, metal, plastic, wool, fabric, glass }
}