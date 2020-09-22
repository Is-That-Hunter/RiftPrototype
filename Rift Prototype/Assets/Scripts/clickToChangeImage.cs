using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickToChangeImage : MonoBehaviour
{
    [SerializeField] GameObject target;
    //public Image icon = null;
    public void changeImg(Sprite currentImg)
    {
        // this is so wrong but logic is right
        // find object and put name here
        // finish up image transfer
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = currentImg;
    }
}
