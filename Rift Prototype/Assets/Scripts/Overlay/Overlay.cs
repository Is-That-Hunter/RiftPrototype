using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    public GameObject prompt;
    private TMPro.TextMeshProUGUI text;
    public GameObject promptBox;
    public bool promptActive;
    public bool isPlaying;
    public StateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] ts = this.gameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts)
        {
            if(t.gameObject.name == "Prompt")
            {
                this.prompt = t.gameObject;
                text = this.prompt.GetComponent<TMPro.TextMeshProUGUI>();
            }
            if(t.gameObject.name == "PromptBox")
            {
                this.promptBox = t.gameObject;
            }
        }
        this.changePromptActive(false);
    }

    public void changePrompt(string prompt)
    {
        text.text = prompt;
    }
    public void changePromptActive(bool isActive)
    {
        if(isActive && stateMachine.peekState().stateName == "Player")
        {
            promptActive = isActive;
            text.enabled = promptActive;
            this.promptBox.SetActive(promptActive);
        }
        else if(!isActive) {
            promptActive = isActive;
            text.enabled = promptActive;
            this.promptBox.SetActive(promptActive);
        }
        
    }
    public void forceChangePromptActive(bool isActive)
    {
        promptActive = isActive;
        text.enabled = promptActive;
        this.promptBox.SetActive(promptActive);
    }
}
