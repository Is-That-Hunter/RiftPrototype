using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

//For Displaying Portraits next to Dialogue
[System.Serializable]
public class CharacterPortrait
{
    public string name;
    public Sprite portrait;
    public GameObject character;
}
public class TwineParser : MonoBehaviour
{
    public List<Twine> dialogueTrees = new List<Twine>();
    public string[] dialogueJsons;
    public GameObject mainCamera;
    public CharacterPortrait[] characters;
    public GlobalScript global_variables;
    public bool inArea;
    public string currTree;
    void Start()
    {
        global_variables = gameObject.GetComponent<SceneScript>().globalScript;
        foreach(string json in dialogueJsons)
        {
            Twine tree = FromJson(json);
            this.dialogueTrees.Add(tree);
            parseAllDialogue(tree);
        }
    }

    Twine FromJson(string file) 
    {
        string dialoguePath = Resources.Load<TextAsset>("JSON/"+file).text;
        Twine tree = JsonUtility.FromJson<Twine>(dialoguePath);
        return tree;
    }

    public void parseAllDialogue(Twine tree) {
        foreach(Passage p in tree.passages)
        {
            p.parsedText = this.formatTextForClickable(p);
        }
    }

    public int getCurrPid(string tree = "")
    {
        if(tree == "")
            tree = this.currTree;
        Twine thisTree = dialogueTrees.FirstOrDefault(i=>i.name == tree);
        return thisTree.currPid;
    }

    public Passage getCurrPassage(string tree = "") {
        if(tree == "")
            tree = this.currTree;
        Twine thisTree = dialogueTrees.FirstOrDefault(i=>i.name == tree);
        if(thisTree != null)
        {
            foreach(Passage p in thisTree.passages)
            {
                if(Int32.Parse(p.pid)==thisTree.currPid)
                    return p;
            }
        }
        return null;
    }
    public CharacterPortrait getCharacterPortrait(string character) {
        CharacterPortrait charPortrait = characters.FirstOrDefault(i=>i.name == character);
        return charPortrait;
    }
    public CharacterPortrait getCurrCharacterPortrait(string tree = "") {
        if(tree == "")
            tree = this.currTree;
        return this.getCharacterPortrait(this.getCurrPassage(tree).character);
    }

    public string getCurrText(string tree = "") {
        if(tree == "")
            tree = this.currTree;
        Passage p = this.getCurrPassage(tree);
        if(p.hasVar)
            return formatTextForClickable(p);
        return p.parsedText;
    }

    public bool chooseOption(string option) {
        string tree = currTree;
        Twine thisTree = dialogueTrees.FirstOrDefault(i=>i.name == tree);
        if(thisTree != null)
        {
            Passage p = this.getCurrPassage(tree);
            Link[] options = p.links;
            Link choice = options.FirstOrDefault(i=>i.link == option);
            if (choice != null)
            {
                thisTree.currPid = Int32.Parse(choice.pid);
                return choice.leave;
            }
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
    //Parses out the dialogue to be clickable if it is a link
    public string formatTextForClickable(Passage p)
    {
        string text = p.text;
        string[] textArr = text.Split('\n');
        List<string> textLinks = new List<string>();
        string ret = "";
        p.hasVar = false;
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

    public void changePid(string tree, int pid) {
        Twine thisTree = dialogueTrees.FirstOrDefault(i=>i.name == tree);
        if(thisTree != null)
        {
            thisTree.currPid = pid;
        }
    }
}
