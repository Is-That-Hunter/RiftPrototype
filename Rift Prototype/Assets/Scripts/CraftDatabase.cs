using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CraftDatabase : MonoBehaviour
{
    //All right lets make our selves a dictionary of what we can craft
    //Already tested whether this will carry over to future copies of this object, and it should
    //The goal of this script is to make it so we can easily reference the key(Three Component Types) to the value (the game Object it will refer to)
    //Preferably we probably want to make the value the crafted game object but for the time being I'll be using Strings of their names

    private void OnEnable()
    {
        Dictionary<(string, string, string), string> data = new Dictionary<(string, string, string), string>
        {
            { ("small", "electric", "metal"), "flashlight" },
        };

    }
}
