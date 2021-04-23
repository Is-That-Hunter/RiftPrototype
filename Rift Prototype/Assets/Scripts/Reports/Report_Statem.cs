using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Report_Statem : StateInterface
{
    // Start is called before the first frame update
    public ItemTrigger iT;
    public Sprite Police;
    public Sprite Safety;
    public Sprite Foreman;
    
    public StateMachine state_m;

    public MainController controls;

    private void Awake()
    {
        controls = new MainController();

        controls.Report.Escape.performed += escape => DisableImage();
    }

    void Start()
    {
        string currentObj = iT.currentCol.name;
        Debug.Log(currentObj);
        switch (currentObj)
        {
            case "PoliceReport":
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Police;
                break;
            case "GoldbergSafetyReport":
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Safety;
                break;
            case "ForemansReport":
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Foreman;
                break;
        }
    }

    public void DisableImage()
    {
        state_m.popState();
    }

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new MainController();
        }
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
