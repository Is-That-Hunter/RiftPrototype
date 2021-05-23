using System;
//Parsing Dialogue Text Files
[System.Serializable]
public class Twine
{
    public string name;
    public Passage[] passages;
    public int currPid;
}
[System.Serializable]
public class Passage
{
    public bool zoom;
    public bool zoomObj;
    public string character;
    public string parsedText;
    public string text;
    public Link[] links;
    public string name;
    public string pid;
    public bool hasVar;
}
[System.Serializable]
public class Link
{
    public bool leave;
    public string name;
    public string link;
    public string pid;
}