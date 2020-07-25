using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;


[ExecuteInEditMode]
public class CraftingMaterial : MonoBehaviour
{
    public TextAsset tagStuff;
    public Craft itemTags;

    private Tags allTags = new Tags();

    //dictionary stuff
    public List<string> sizeTags = new List<string>();
    public List<string> typeTags = new List<string>();
    public List<string> materialTags = new List<string>();

    private void OnEnable()
    {
        //Reading in the types of tags available
        allTags = JsonUtility.FromJson<Tags>(tagStuff.text);
        foreach (Stringable item in allTags.size)
        {
            sizeTags.Add(item.thing);
        }
        foreach (Stringable item in allTags.type)
        {
            typeTags.Add(item.thing);
        }
        foreach (Stringable item in allTags.material)
        {
            materialTags.Add(item.thing);
        }

    }
}

[CustomEditor(typeof(Craft))]
public class CraftEditor : Editor
{
    private int sizeIdx = 0;
    private int typeIdx = 0;
    private int materialIdx = 0;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CraftingMaterial script = (CraftingMaterial)target;

        GUIContent sizeList = new GUIContent("Size");
        sizeIdx = EditorGUILayout.Popup(sizeList, sizeIdx, script.sizeTags.ToArray());

        GUIContent typeList = new GUIContent("Type");
        typeIdx = EditorGUILayout.Popup(typeList, typeIdx, script.typeTags.ToArray());

        GUIContent materialList = new GUIContent("Material");
        materialIdx = EditorGUILayout.Popup(materialList, materialIdx, script.materialTags.ToArray());
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

[Serializable]
public class Craft : MonoBehaviour
{
    public string size;
    public string type;
    public string material;
}