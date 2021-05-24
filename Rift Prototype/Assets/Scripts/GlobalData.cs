using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GlobalData : MonoBehaviour
{
    //DataBases
    public string itemsJson;
    public Inventory inventory;
    public ItemDatabase itemDatabase;
    public CraftDatabase craftDatabase;
    //Other Object References
    public CameraController mainCamera;
    //    Set States in Editor: Player, Inventory, Dialogue, Pause, Report
    public List<State> states;
    public GameObject player;
    public UIInventory uiInventory;
    public LoadProgressBar loadingSceneOverlay;
    public Overlay overlay;
    public EventSystem eventSystem;
    //Other scripts on Object
    public TwineParser twineParser;
    public SequenceHandler sequenceHandler;
    public StateMachine stateMachine;
    //Local Scene Data
    public bool sceneLoaded;
    private bool ignore;
    public string[] startingItems;
    public List<string> destroyedMonsters = new List<string>();
    //0: objectName, 1: itemState
    public string[] placeableObjects = {"Ghost", "ToBeDestroyed", "Ghost"};

    public int endGame = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        sceneLoaded = true;
        twineParser = gameObject.GetComponent<TwineParser>();
        sequenceHandler = gameObject.GetComponent<SequenceHandler>();
        stateMachine = gameObject.GetComponent<StateMachine>();
        inventory = new Inventory();
        FromJson();
        foreach(string invItem in startingItems)
        {
            inventory.AddItem(itemDatabase.FindItem(invItem));
        }

        //This is for test purposes due to current lack of State Switcher
        //This code can be used in the switch to the Inv/Craft State
        uiInventory.SetInventory(inventory);
        Debug.Log("Global Data: Start");
    }
    private void OnEnable()
    {
        Debug.Log("Global Data: OnEnable");
    }
    private void OnDisable()
    {
        Debug.Log("Global Data: OnDisable");
    }
    public IEnumerator LoadScene(string newSceneName)
    {
        ignore = false;
        Debug.Log("NEW SCENE: " + newSceneName);
        bool once = false;
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "FullScene")
        {
            saveCarnivalData();
        }
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(newSceneName);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        loadingSceneOverlay.Active(true);
        loadingSceneOverlay.UpdateBar(0);
        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Debug.Log("Pro :" + asyncOperation.progress);
            //Output the current progress
            loadingSceneOverlay.UpdateBar(asyncOperation.progress);

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Activate the Scene
                    
                if(!once && endGame == 0)
                {
                    sequenceHandler.handleAction(new TriggerInfo(false,true,"",-1), "Scene");
                    once = true;
                    
                    asyncOperation.allowSceneActivation = true;
                }
                else if(endGame == 2)
                {
                    asyncOperation.allowSceneActivation = true;
                }
                //Send Scene Entered Trigger, and close all stuck overlays
                
                if(mainCamera.skyCamStatus != 1)
                    overlay.changePromptActive(false);
            }
            yield return null;
        }
        if(asyncOperation.isDone)
        {
            mainCamera.waitforslow = true;
            ignore = true;
            //sceneLoaded = true;
            LoadCarnivalData();
        }
    
    }
    public void releaseTheStates() {
        stateMachine.enableTopState();
    }
    public void noTopState() {
        stateMachine.disableTopState();
    }

    void FixedUpdate()
    {
        if(!sceneLoaded && !mainCamera.waitforslow && ignore)
        {
            sceneLoaded = true;
            loadingSceneOverlay.Active(false);
        }
    }
    void FromJson() 
    {
        string itemsString = Resources.Load<TextAsset>("JSON/"+itemsJson).text;
        Item[] items = JsonUtility.FromJson<Items>(itemsString).items;
        itemDatabase = new ItemDatabase(items);
        craftDatabase = new CraftDatabase(items.Where(item => item.craftable == true).ToArray());
    }

    public void LoadCarnivalData()
    {
        foreach (string monsterName in destroyedMonsters) {
            GameObject monster = GameObject.Find(monsterName);
            if(monster != null) {
                Destroy(monster);
            }
        }
        foreach (string objectVars in placeableObjects) {
            GameObject[] objs = {GameObject.Find("CrossingPlankParent"), GameObject.Find("PadlockParent"), GameObject.Find("CannonParent")};
            if(objs[0] != null && placeableObjects[0] != null) 
            {
                foreach(GameObject obj in objs)
                {
                    ItemTag tag = obj.GetComponentsInChildren<ItemTag>()[0];
                    switch(obj.name)
                    {
                        case "CrossingPlankParent":
                            tag.setState(placeableObjects[0]);
                            break;
                        case "PadlockParent":
                            tag.setState(placeableObjects[1]);
                            break;
                        case "CannonParent":
                            tag.setState(placeableObjects[2]);
                            break;
                    }
                }
            }
        }
    }
    public void saveCarnivalData()
    {
        GameObject[] objs = {GameObject.Find("CrossingPlankParent"), GameObject.Find("PadlockParent"), GameObject.Find("CannonParent")};
        if(objs[0] != null) 
        {
            foreach(GameObject obj in objs)
            {
                ItemTag tag = obj.GetComponentsInChildren<ItemTag>()[0];
                switch(obj.name)
                {
                    case "CrossingPlankParent":
                        placeableObjects[0] = tag.itemState;
                        break;
                    case "PadlockParent":
                        placeableObjects[1] = tag.itemState;
                        break;
                    case "CannonParent":
                        placeableObjects[2] = tag.itemState;
                        break;
                }
            }
        }
    }

    public void endCutscene()
    {
        if(endGame == 1)
        {
            endGame = 2;
        }
        if(mainCamera.skyCamStatus == 1)
        {
            mainCamera.skyCamStatus = 2;
            mainCamera.GetComponent<Camera>().enabled = true;
            Destroy(mainCamera.skyCam.gameObject);
            releaseTheStates();
            overlay.changePromptActive(false);
        }
    }
}
