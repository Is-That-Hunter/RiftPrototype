using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

//Parsing Dialogue Text Files
[System.Serializable]
public class twine
{
    public passage[] passages;
}
[System.Serializable]
public class passage
{
    public string character;
    public string parsedText;
    public string text;
    public links[] links;
    public string name;
    public string pid;
    public bool hasVar;
}
[System.Serializable]
public class links
{
    public bool leave;
    public string name;
    public string link;
    public string pid;
}
//For Displaying Portraits next to Dialogue
[System.Serializable]
public class characterPortraits
{
    public string name;
    public Sprite portrait;
    public GameObject character;
}
public class twineParser : MonoBehaviour
{
    private twine dialogueTree;
    public string dialogueJson;
    public int currPid;
    public GameObject mainCamera;
    public characterPortraits[] characters;
    public bool inArea = false;
    public Global_Script global_variables;
    void Start()
    {
        global_variables = gameObject.GetComponent<Global_Script>();
        FromJson();
        parseAllDialogue();
    }

    void FromJson() 
    {
        string dialoguePath = Resources.Load<TextAsset>("JSON/"+dialogueJson).text;
        twine dialogue = JsonUtility.FromJson<twine>(dialoguePath);
        this.dialogueTree = dialogue;
    }
    public void parseAllDialogue() {
        foreach(passage p in this.dialogueTree.passages)
        {
            p.parsedText = this.formatTextForClickable(p);
        }
    }
    public passage getCurrPassage() {
        foreach(passage p in this.dialogueTree.passages)
        {
            if(Int32.Parse(p.pid)==this.currPid)
                return p;
        }
        return null;
    }
    public characterPortraits getCurrCharacterPortraits() {
        passage p = getCurrPassage();
        foreach(characterPortraits charPortrait in this.characters)
        {
            if(p.character == charPortrait.name)
                return charPortrait;
        }
        return null;
    }
    public Sprite getCurrPortrait() {
        return getCurrCharacterPortraits().portrait;
    }
    public GameObject getCurrCharacterFocus() {
        return getCurrCharacterPortraits().character;
    }

    public string getCurrText() {
        passage p = this.getCurrPassage();
        if(p.hasVar)
            return formatTextForClickable(this.getCurrPassage());
        return p.parsedText;
    }

    public bool chooseOption(string option) {
        links[] options = this.getCurrPassage().links;
        links choice = options.FirstOrDefault(i=>i.link == option);
        if (choice != null)
        {
            this.currPid = Int32.Parse(choice.pid);
            return choice.leave;
        }
        return false;
    }
    //index 0 = name, index 1 = link
    //returns name and link from link in text
    private string[] getNameAndLink(string parseThis)
    {
        if(parseThis.Contains("->"))
            return parseThis.Split(new string[]{"->"}, StringSplitOptions.None);
        string[] ret = {parseThis,parseThis};
        return ret;
    }
    //compares variable in text to see if it exists and is true
    private bool compareStringAndVariable(string parseThis)
    {
        if(global_variables.inventory.itemInInventory(parseThis))
            return true;
        return false;
    }
    //formats links so that they link to something and are colored correctly
    //If an variable option exists color it red
    private string linkToHTML(string[] parseThis, bool isVar = false)
    {
        string color = "blue";
        if(isVar)
            color = "red";
        string temp = "<link=\""+parseThis[1]+"\"><color="+color+">"+parseThis[0]+"</color></link>";
        return temp;
    }
    public string formatTextForClickable(passage p)
    {
        string text = p.text;
        string[] textArr = text.Split('\n');
        List<string> textLinks = new List<string>();
        string ret = "";
        for(int i = 0; i < textArr.Length; i++) {
            bool newline = true;
            //For If Statements in Text
            if(textArr[i].Contains("(if:"))
            {
                //Get Indexes
                int ifStart = textArr[i].IndexOf("(if:");
                int ifEnd = textArr[i].IndexOf(")");
                int linkStart = textArr[i].IndexOf("[[[");
                int linkEnd = textArr[i].IndexOf("]]]");
                //Get Strings
                string fullLink = textArr[i].Substring(linkStart+3,linkEnd-linkStart-3);
                string varName = textArr[i].Substring(ifStart+4,ifEnd-ifStart-4);
                //Parse If and String
                string[] nameAndLink = this.getNameAndLink(fullLink);
                bool isActive = compareStringAndVariable(varName);
                p.hasVar = true;
                if(isActive) {
                    ret += this.linkToHTML(nameAndLink);
                }
                else
                    newline = false;
            }
            //For Links in Text
            else if(textArr[i].Contains("[["))
            {
                //Get Indexes
                int linkStart = textArr[i].IndexOf("[[");
                int linkEnd = textArr[i].IndexOf("]]");
                //Get Strings
                string fullLink = textArr[i].Substring(linkStart+2,linkEnd-linkStart-2);
                string[] nameAndLink = this.getNameAndLink(fullLink);
                ret += this.linkToHTML(nameAndLink);
            }
            //For Text
            else
            {
                ret += textArr[i];
            }
            //Add NewLine unless last line
            if(newline)
                ret += "\n";
        }
        return ret;
    }

    public void changePid(int pid) {
        this.currPid = pid;
    }
}
