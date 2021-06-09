using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainMenuOverlay : MonoBehaviour
{
    public List<Image> Options = new List<Image>();
    private Sprite ButtonImage;
    private Sprite ButtonHoverImage;

    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        ButtonImage = Resources.Load<Sprite>("Sprites/UI/BigDialogueBoxCropped");
        ButtonHoverImage = Resources.Load<Sprite>("Sprites/UI/BigDialogueBoxCroppedHover");
        Transform[] ts = this.gameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            if(t.gameObject.name == "Options")
            {
                foreach(Transform option in t.gameObject.GetComponentsInChildren<Transform>(true)) {
                    Image temp = option.GetComponent<Image>();
                    if(temp)
                        Options.Add(temp);
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
        Image current = Options.Where(x => x.name == Obj.transform.name).First();
        if(current != null) {
            current.sprite = ButtonHoverImage;
        }
    }
    public void onExit(GameObject Obj) {
        Image current = Options.Where(x => x.name == Obj.transform.name).First();
        if(current != null) {
            current.sprite = ButtonImage;
        }
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
