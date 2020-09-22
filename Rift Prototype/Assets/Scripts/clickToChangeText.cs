using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class clickToChangeText : MonoBehaviour
{

    public TextMeshProUGUI desctextshown = null;
    public TextMeshProUGUI tagtextshown = null;
    public void changeDesc (string desc)
    {
        desctextshown.text = desc;
    }
    public void changeTags(string tags)
    {
        tagtextshown.text = tags;
    }
}
