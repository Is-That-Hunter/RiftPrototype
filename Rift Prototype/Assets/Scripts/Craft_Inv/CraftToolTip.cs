using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraftToolTip : MonoBehaviour
{
    public Vector2 offset;
    // Update is called once per frame
    void Update () {
        Vector2 Pos = Mouse.current.position.ReadValue();
        transform.position = Pos + offset;
    }
    public void changeText(string _text)
    {
        gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = _text;
    }
    private void OnDisable()
    {
        
    }
    private void OnEnable()
    {
        Vector2 Pos = Mouse.current.position.ReadValue();
        transform.position = Pos + offset;
    }
}
