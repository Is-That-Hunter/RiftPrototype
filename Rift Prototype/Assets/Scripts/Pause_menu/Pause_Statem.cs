using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pause_Statem : StateInterface
{
    public StateMachine state_m;
    public MainController controls;
    public Button resume, quit;

    private void Awake()
    {
        controls = new MainController();

        controls.Pause_Menu.Unpause.performed += unpause => Unpause();
    }

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        resume.onClick.AddListener(Unpause);
        quit.onClick.AddListener(QuitGame);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        state_m.popState();
    }

    public void QuitGame()
    {
        Application.Quit();
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