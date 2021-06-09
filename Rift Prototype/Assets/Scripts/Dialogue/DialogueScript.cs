using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueScript : StateInterface, IPointerClickHandler
{
    public GlobalData globalData;
    public GameObject dialogueText; 
    public GameObject characterHead;
    public CameraController mainCamera;
    public StateMachine stateMachine;
    public TwineParser twineParser;
    // Start is called before the first frame update
    void Start()
    {
        //changePortrait();
    }

    public void changePortrait() {
        CharacterPortrait charPortrait = twineParser.getCurrCharacterPortrait();
        this.characterHead.GetComponent<Image>().sprite = charPortrait.portrait;
        this.mainCamera.focusObject = charPortrait.character.transform;
    }

    public void updateDialogueBox() {
        this.mainCamera.focus = true;
        Passage p = twineParser.getCurrPassage();
        this.mainCamera.zoomIn = p.zoom;
        this.mainCamera.focusOther = p.zoomObj;
        string text = twineParser.getCurrText();
        this.dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = text;
    }

    public void OnPointerClick(PointerEventData eventData) {
        TMP_Text pTextMeshPro = this.dialogueText.GetComponent<TMP_Text>();
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, null);  // If you are not in a Canvas using Screen Overlay, put your camera instead of null
        if (linkIndex != -1) {
            TMP_LinkInfo linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
            var linkId = linkInfo.GetLinkID();
            int leavingPid = twineParser.getCurrPid();
            string currTree = twineParser.currTree;
            bool leave = twineParser.chooseOption(linkId);
            updateDialogueBox();
            changePortrait();
            stateMachine.handleAction("Dialogue",leave,false,"",leavingPid,currTree);
            Debug.Log("linkId: " + linkId + "\nleavingPid: " + leavingPid + "\ncurrTree: " + currTree + "\nleave: " + leave);
            if(leave)
            {
                this.mainCamera.focus = false;
                this.mainCamera.zoomIn = false;
                stateMachine.popState(pid: leavingPid, tree: currTree);
            }
        }
    }
    /*
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Entered");
        TMP_Text pTextMeshPro = this.dialogueText.GetComponent<TMP_Text>();
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, null);  // If you are not in a Canvas using Screen Overlay, put your camera instead of null
        if (linkIndex != -1) {
            Debug.Log("Highlight link");
            TMP_LinkInfo linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
            for( int i = 0; i < linkInfo.linkTextLength; i++ ) { // for each character in the link string
                int characterIndex = linkInfo.linkTextfirstCharacterIndex + i; // the character index into the entire text
                var charInfo = pTextMeshPro.textInfo.characterInfo[characterIndex];
                int meshIndex = charInfo.materialReferenceIndex; // Get the index of the material / sub text object used by this character.
                int vertexIndex = charInfo.vertexIndex; // Get the index of the first vertex of this character.

                Color32[] vertexColors = pTextMeshPro.textInfo.meshInfo[meshIndex].colors32; // the colors for this character

                if( charInfo.isVisible ) {
                    vertexColors[vertexIndex + 0] = Color.white;
                    vertexColors[vertexIndex + 1] = Color.white;
                    vertexColors[vertexIndex + 2] = Color.white;
                    vertexColors[vertexIndex + 3] = Color.white;
                }
            }
            pTextMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Exited");
    }
    */
    void OnEnable()
    {
        if(isActive)
            updateDialogueBox();
    }
}
