using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class clickToChangeText : MonoBehaviour
{

    public TextMeshProUGUI textshown = null;
    public void changeWord (string word)
    {
        textshown.text = word;
    }
}
