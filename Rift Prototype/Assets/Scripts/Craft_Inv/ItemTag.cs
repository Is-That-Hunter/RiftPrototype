using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//Attatch to Item Tagged Objects and edit its name for each item
public class ItemTag : MonoBehaviour
{
    public List<ItemName> items = new List<ItemName>();
    public List<GameObject> relatedObjects = new List<GameObject>();
    public string itemState = "Static"; 
    //"Static", "Ghost", "Created", "ToBeDestroyed", "Destroyed", "Filled", "Shot"
    public bool indicator = false;
    public bool destroyed = false;
    public bool infinite = false;
    public float timeTillRespawn = 0.0f;
    public float respawnTime = 5.0f;
    private BoxCollider ParentCollider;
    public Material[] ObjMaterials_;
    private List<Material> ObjMaterials = new List<Material>();
    public float Transparency = 0.2f;
    //If we want the indicator to be an object above the Item
    public float arrowSpeed = .3f;
    public float minY = 1.5f;
    public float maxY = 2f;
    private Transform pointer;

    private void Start()
    {
        if(itemState == "")
            itemState = "Static";
        Transform[] ts = this.transform.parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            if(t.gameObject.name == "Pointer")
            {
                pointer = t;
                if(!indicator)
                    pointer.gameObject.SetActive(false);
            }
            else 
            {
                ItemName itemName = t.GetComponent<ItemName>();
                if(itemName != null) {
                    items.Add(itemName);
                }
                else if(t.gameObject.name != "Collider")
                {
                    relatedObjects.Add(t.gameObject);
                }
            }
        }
        
        //if(pointer != null)
        //    pointer.gameObject.SetActive(indicator);
        
        if(itemState == "Ghost")
        {
            foreach(ItemName item in items)
            {
                MeshRenderer mesh = item.GetComponent<MeshRenderer>();
                if(mesh != null)
                {
                    ObjMaterials.AddRange(mesh.materials);
                }
                else {
                    foreach(MeshRenderer meshes in item.GetComponentsInChildren<MeshRenderer>())
                    {
                        ObjMaterials.AddRange(meshes.materials);
                    }
                }
            }
            foreach(Material mat in ObjMaterials)
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, Transparency);
            }
        }
        ParentCollider = gameObject.transform.parent.GetComponent<BoxCollider>();
        if(items.Count() == 0)
        {
            Debug.Log("No Items in Item Tag");
        }
    }

    private void Update()
    {
        if(indicator && itemState == "Ghost")
        {
            float move = pointer.position.y + (arrowSpeed * Time.deltaTime);
            if(move > maxY)
            {
                arrowSpeed *= -1;
                move = maxY;
            }
            else if(move < minY)
            {
                arrowSpeed *= -1;
                move = minY;
            }
            pointer.position = new Vector3(pointer.position.x, move, pointer.position.z);
        }
        else if(itemState == "Static")
        {
            if(timeTillRespawn != 0.0f)
            {
                destroyed = true;
                timeTillRespawn -= Time.deltaTime;
                if(timeTillRespawn < 0.0f)
                {
                    timeTillRespawn = 0.0f;
                    destroyed = false;
                }
            }
            if(destroyed && !infinite)
            {
                if(ParentCollider != null)
                    ParentCollider.enabled = false;
                items.First().gameObject.SetActive(false);
            }
            if(!destroyed && !infinite)
            {
                if(ParentCollider != null)
                    ParentCollider.enabled = true;
                items.First().gameObject.SetActive(true);
            }
        }
    }

    public void setIndicator(bool active)
    {
        if(itemState == "Ghost")
        {
            indicator = active;
            //For object above
            pointer.gameObject.SetActive(active);
            //For fading
            foreach(Material mat in ObjMaterials)
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, Transparency);
            }
        }
    }
    public void setState(string newState, string choice)
    {
        itemState = newState;
        if(newState == "Created")
        {
            setIndicator(false);
            foreach(Material mat in ObjMaterials)
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1.0f);
            }
            List<ItemName> newItems = new List<ItemName>();
            foreach(ItemName i in items)
            {
                if(i.itemName != choice)
                    Destroy(i.gameObject);
                else
                    newItems.Add(i);
            }
            items = newItems;
        }
        else if(newState == "Ghost")
        {
            setIndicator(true);
        }
        else if(newState == "Destroyed")
        {
            foreach(ItemName item in items)
                item.gameObject.SetActive(false);
            foreach(GameObject obj in relatedObjects)
                obj.SetActive(false);
        }
    }
}
