using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attatch to Item Tagged Objects and edit its name for each item
public class ItemTag : MonoBehaviour
{
    public string attachedItemName;
    public string[] otherNames;
    //public bool placeable = false;
    public string itemState = "Static"; 
    //"Static", "Ghost", "Created", "ToBeDestroyed", "Destroyed", "Filled", "Shot"
    //public bool created = false;
    public bool special = false;
    public bool indicator = false;
    public bool destroyed = false;
    public bool infinite = false;
    public float timeTillRespawn = 0.0f;
    public float respawnTime = 5.0f;
    public GameObject Obj;
    public GameObject[] OtherObjs;
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
        if(attachedItemName == null)
        {
            Debug.Log("ITEM HAS NO ITEM");
        }
        if(itemState == "")
            itemState = "Static";
        Transform[] ts = this.transform.parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            if(t.gameObject.name == "Pointer")
            {
                pointer = t;
            }
            else if(t.gameObject.name != "Collider" && Obj == null)
            {
                Obj = t.gameObject;
            }
        }
        
        if(pointer != null)
            pointer.gameObject.SetActive(indicator);
        
        if(itemState == "Ghost")
        {
            if(Obj != null && Obj.GetComponent<MeshRenderer>() != null)
            {
                ObjMaterials_ = Obj.GetComponent<MeshRenderer>().materials;
                foreach(Material mat in ObjMaterials_ )
                {
                    ObjMaterials.Add(mat);
                }
            }
            else if(Obj == null && Obj.GetComponentsInChildren<MeshRenderer>() != null)
            {
                foreach(MeshRenderer meshes in Obj.GetComponentsInChildren<MeshRenderer>())
                {
                    ObjMaterials_ = meshes.materials;
                    foreach(Material mat in ObjMaterials_ )
                    {
                        ObjMaterials.Add(mat);
                    }
                }
            }
            if(special)
            {
                foreach(GameObject g in OtherObjs)
                {
                    foreach(Transform t in g.GetComponentInChildren<Transform>())
                    {
                        foreach(MeshRenderer meshes in t.GetComponentsInChildren<MeshRenderer>())
                        {
                            ObjMaterials_ = meshes.materials;
                            foreach(Material mat in ObjMaterials_ )
                            {
                                ObjMaterials.Add(mat);
                            }
                        }
                    }
                }
            }
            foreach(Material mat in ObjMaterials)
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, Transparency);
            }
        }
        ParentCollider = gameObject.transform.parent.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(itemState == "Ghost")
        {
            if(indicator)
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
        }
        else if(Obj != null && itemState == "Static")
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
                Obj.SetActive(false);
            }
            if(!destroyed && !infinite)
            {
                if(ParentCollider != null)
                    ParentCollider.enabled = true;
                Obj.SetActive(true);
            }
        }
    }

    public void setIndicator(bool active)
    {
        //if(!created && placeable)
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
    public void setState(string newState)
    {
        itemState = newState;
        if(newState == "Created")
        {
            setIndicator(false);
            foreach(Material mat in ObjMaterials)
            {
                mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1.0f);
            }
        }
        else if(newState == "Ghost")
        {
            setIndicator(true);
        }
        else if(newState == "Destroyed")
        {
            Obj.SetActive(false);
            OtherObjs[0].SetActive(false);
        }
    }
}
