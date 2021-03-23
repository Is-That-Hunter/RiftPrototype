using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuOverlay : MonoBehaviour
{
    public List<Transform> Options = new List<Transform>();

    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] ts = this.gameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            if(t.gameObject.name == "Options")
            {
                foreach(Transform option in t.gameObject.GetComponentsInChildren<Transform>(true)) {
                    if(option.GetComponent<Image>() != null)
                        Options.Add(option);
                }
            }
        }
    }
    public void clickOption(string name) {
        Debug.Log(name);
        switch(name) {
            case "Tutorial":
                SceneManager.LoadScene("Entrance");
                break;
            case "Credits":
                credits.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Exit":
                Application.Quit();
                break;
        }
    }
    public void onEnter(GameObject Obj) {

    }
    public void onExit(GameObject Obj) {

    }
    /*public void OnPointerClick(PointerEventData eventData) {
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);
        if(raycastResults.Count > 0)
        {
            foreach(var result in RaycastResults)
            {
                foreach(Transform Option in Options) {
                    Image OptionImage = Option.GetComponent<Image>();
                }
            }
        }
    }*/
}
