using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Credit_Button : MonoBehaviour
{
    public Button back;
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(goBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goBack()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
