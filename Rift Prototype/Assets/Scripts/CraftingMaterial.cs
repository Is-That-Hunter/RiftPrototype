using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class CraftingMaterial : MonoBehaviour
{
    public TextAsset tagStuff;
    private Tags allTags;
    // Start is called before the first frame update
    void Start()
    {
        string tagDirection = AssetDatabase.GetAssetPath(tagStuff);
        StreamReader stream = new StreamReader(tagDirection);
        string tagJSON = stream.ReadToEnd();
        allTags = JsonUtility.FromJson<Tags>(tagJSON);
        Debug.Log(allTags.size.ToString());
        foreach (Stringable thing in allTags.size)
        {
            Debug.Log("sizes: " + thing);
        }
        foreach (Stringable thing in allTags.type)
        {
            Debug.Log("types: " + thing);
        }
        foreach (Stringable thing in allTags.material)
        {
            Debug.Log("materials: " + thing);
        }

    }
}

//Strings need to be wrapped to work with JSON. I don't understand why.

[Serializable]
public class Tags
{
    public Stringable[] size;
    public Stringable[] type;
    public Stringable[] material;
}

[Serializable]
public class Stringable
{
    public string thing;
}
