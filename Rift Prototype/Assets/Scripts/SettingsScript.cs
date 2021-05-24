using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
public class GraphicsSettings
{
    public FullScreenMode[] fullScreenOptions = {FullScreenMode.FullScreenWindow, FullScreenMode.Windowed};
    Resolution[] resolutions;

    //public void setFullScreen();
}

public class SettingsScript : MonoBehaviour
{
    public MusicHandler musicHandler;
    //public ;
    void Start() {
    }

}
