using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMaterial : MonoBehaviour
{
    public TextAsset tagTypes;

    // Start is called before the first frame update
    void Start()
    {
        Tags allTags = JsonUtility.FromJson<Tags>(tagTypes.text);
        Debug.Log(allTags);
        foreach (var thing in allTags.size)
        {
            Debug.Log("sizes: " + thing);
        }
        foreach (var thing in allTags.type)
        {
            Debug.Log("sizes: " + thing);
        }
        foreach (var thing in allTags.material)
        {
            Debug.Log("sizes: " + thing);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

//Strings need to be wrapped to work with JSON. I don't understand why.

public class Tags
{
    public Stringable[] size;
    public Stringable[] type;
    public Stringable[] material;
}

public class Stringable
{
    string thing;
}
