using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadProgressBar : MonoBehaviour
{
    public Text m_Text;
    public bool isActive;
    public Image image;
    
    public void UpdateBar(float progress) {
        //m_Text.text = "Loading progress: " + (progress * 100) + "%";
        //gameObject.SetActive(active);
    } 
    public void Active(bool active)
    {
        isActive = active;
        image.enabled = active;
    }
}