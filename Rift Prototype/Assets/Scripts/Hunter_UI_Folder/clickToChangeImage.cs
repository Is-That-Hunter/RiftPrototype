using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickToChangeImage : MonoBehaviour
{
    public Image currentIcon = null;
    public void changeImg(Sprite currentImg)
    {
        currentIcon.sprite = currentImg;
    }

}

