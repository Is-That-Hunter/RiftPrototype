using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    Dictionary<InventoryItem, int> Inventory = new Dictionary<InventoryItem, int>();

    private void OnEnable()
    {
        string AngelaInventoryString = System.IO.File.ReadAllText(Application.persistentDataPath + "/AngelaInventory.json");
        //Load as Array
        InvArray _tempLoadListData = new InvArray();
        JsonUtility.FromJsonOverwrite(AngelaInventoryString, _tempLoadListData);
        Debug.Log(_tempLoadListData);
        //Convert to List
        List<InventoryItem> loadInventory = _tempLoadListData.InventoryStuff.ToList<InventoryItem>();
        //Convert to dict
        foreach (InventoryItem thing in loadInventory) {
            Debug.Log(thing.nameAgain);
            if(Inventory.ContainsKey(thing))
            {
                Inventory[thing] = Inventory[thing]++;
            }
            else
            {
                Inventory[thing] = 1;
            }
        }

        //Delete the JSON so we can better write it
        for(int i = 0; i < loadInventory.Count; i++)
        {
            loadInventory.Remove(loadInventory[i]);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            var itemCollided = collision.gameObject.GetComponent<CraftItemAttributes>();
            InventoryItem newThing = new InventoryItem(itemCollided.name, itemCollided.size.ToString(), itemCollided.type.ToString(), itemCollided.material.ToString());
            if (Inventory.ContainsKey(newThing))
            {
                Inventory[newThing] = Inventory[newThing]++;
            }
            else
            {
                Inventory[newThing] = 1;
            }

            collision.gameObject.SetActive(false); // you've collected it
        }
    }

    //send the information back to the json file
    private void OnApplicationQuit()
    {
        List<InventoryItem> stuffAngelaCollected = new List<InventoryItem>();
        foreach(KeyValuePair<InventoryItem, int> thing in Inventory)
        {
            stuffAngelaCollected.Add(thing.Key);
            for (int i = 1; i < thing.Value; i++)
            {
                stuffAngelaCollected.Add(thing.Key);
            }
        }

        InvArray things = new InvArray();
        things.InventoryStuff = stuffAngelaCollected.ToArray();
        string writeIt = JsonUtility.ToJson(things, true);
        Debug.Log(writeIt);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/AngelaInventory.json", writeIt);
    }
}

[System.Serializable]
public class InventoryItem
{
    public string nameAgain, size, type, material;

    public InventoryItem(string _name, string _size, string _type, string _material)
    {
        nameAgain = _name;
        size = _size;
        type = _type;
        material = _material;
    }
}

//Because Unity hates me
[System.Serializable]
public class InvArray
{
    public InventoryItem[] InventoryStuff;
}

//https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity/36244111#36244111
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}