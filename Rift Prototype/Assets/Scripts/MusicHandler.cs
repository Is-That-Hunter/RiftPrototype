using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

[System.Serializable]
public class Music {
    public string fileName;
    public string correspondingScene;
    public AudioClip sceneMusic;
}
[System.Serializable]
public class SoundEffect {
    public AudioClip soundEffect;
    public string audioSourceName;
    public GameObject audioSource;
}

public class MusicHandler : MonoBehaviour
{
    public Music[] musicTracks;
    public SoundEffect[] soundEffects;
    public AudioSource audioSource = new AudioSource();
    public float volume = .5f;
    public bool on = false;
    public 
    void Start() {
        foreach(Music track in musicTracks) {
            track.sceneMusic = Resources.Load<AudioClip>("Audio/"+track.fileName);
            if(track.fileName == SceneManager.GetActiveScene().name) {

            }
        }
        
    }

}
