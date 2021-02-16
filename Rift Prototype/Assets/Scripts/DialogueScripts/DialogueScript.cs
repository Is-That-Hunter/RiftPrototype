using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueScript : stateInterface, IPointerClickHandler
{
    public GameObject dialogueObj;
    public GameObject dialogueText; 
    public GameObject characterHead;
    public GameObject mainCamera;
    public Simple_State_M state_m;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] ts = this.gameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            if(t.gameObject.name == "CharacterHead")
            {
                this.characterHead = t.gameObject;
            }
            if(t.gameObject.name == "DialogueText")
            {
                this.dialogueText = t.gameObject;
            }
        }
        changePortrait();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
            this.mainCamera.GetComponent<CameraController>().focus = true;
            this.mainCamera.GetComponent<CameraController>().zoomIn = true;
            string text= this.dialogueObj.GetComponent<twineParser>().getCurrText();
            this.dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = text;
    }

    public void changePortrait() {
        this.characterHead.GetComponent<Image>().sprite = this.dialogueObj.GetComponent<twineParser>().getCurrPortrait();
        this.mainCamera.GetComponent<CameraController>().focusObject = this.dialogueObj.GetComponent<twineParser>().getCurrCharacterFocus().transform;
    }

    public void OnPointerClick(PointerEventData eventData) {
        TMP_Text pTextMeshPro = this.dialogueText.GetComponent<TMP_Text>();
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, null);  // If you are not in a Canvas using Screen Overlay, put your camera instead of null
        if (linkIndex != -1) {
            TMP_LinkInfo linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
            var linkId = linkInfo.GetLinkID();
            bool leave = this.dialogueObj.GetComponent<twineParser>().chooseOption(linkId);
            changePortrait();
            if(leave)
            {
                this.mainCamera.GetComponent<CameraController>().focus = false;
                this.mainCamera.GetComponent<CameraController>().zoomIn = false;
                state_m.popState();
            }
        }
    }
}
