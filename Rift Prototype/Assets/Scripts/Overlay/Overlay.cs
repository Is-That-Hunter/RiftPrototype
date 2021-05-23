using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    public GameObject prompt;
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
        this.prompt.GetComponent<TMPro.TextMeshProUGUI>().text = prompt;
    }
    public void changePromptActive(bool isActive)
    {
        if(isActive && stateMachine.peekState().stateName == "Player")
        {
            promptActive = isActive;
            this.prompt.GetComponent<TMPro.TextMeshProUGUI>().enabled = promptActive;
            this.promptBox.SetActive(promptActive);
        }
        else if(!isActive) {
            promptActive = isActive;
            this.prompt.GetComponent<TMPro.TextMeshProUGUI>().enabled = promptActive;
            this.promptBox.SetActive(promptActive);
        }
        
    }
}
