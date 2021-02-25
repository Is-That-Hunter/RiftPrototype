using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueScript : StateInterface, IPointerClickHandler
{
    public GameObject globalObj;
    private GameObject dialogueText; 
    private GameObject characterHead;
    public GameObject mainCamera;
    private StateMachine stateMachine;
    private TwineParser twineParser;
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
        this.twineParser = this.globalObj.GetComponent<GlobalScript>().twineParser;
        this.stateMachine = this.globalObj.GetComponent<StateMachine>();
        changePortrait();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
            this.mainCamera.GetComponent<CameraController>().focus = true;
            Passage p = twineParser.getCurrPassage();
            this.mainCamera.GetComponent<CameraController>().zoomIn = p.zoom;
            string text = twineParser.getCurrText();
            this.dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = text;
    }

    public void changePortrait() {
        CharacterPortrait charPortrait = twineParser.getCurrCharacterPortrait();
        this.characterHead.GetComponent<Image>().sprite = charPortrait.portrait;
        this.mainCamera.GetComponent<CameraController>().focusObject = charPortrait.character.transform;
    }

    public void OnPointerClick(PointerEventData eventData) {
        TMP_Text pTextMeshPro = this.dialogueText.GetComponent<TMP_Text>();
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, null);  // If you are not in a Canvas using Screen Overlay, put your camera instead of null
        if (linkIndex != -1) {
            TMP_LinkInfo linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
            var linkId = linkInfo.GetLinkID();
            bool leave = twineParser.chooseOption(linkId);
            changePortrait();
            if(leave)
            {
                this.mainCamera.GetComponent<CameraController>().focus = false;
                this.mainCamera.GetComponent<CameraController>().zoomIn = false;
                stateMachine.popState(pid: twineParser.getCurrPid());
            }
        }
    }
}
