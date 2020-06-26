using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleControl : MonoBehaviour
{
    bool state = false;
    public float speedOfReticle = 50;
    Vector3 reticlePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement of Reticle
        float LeftRight = Input.GetAxis("Horizontal") / 2;
        float UpDown = Input.GetAxis("Vertical") / 2;
        reticlePosition = this.gameObject.transform.position;
        /*
        reticlePosition.x = (float)Screen.width * LeftRight + (Screen.width / 2);
        reticlePosition.y = (float)Screen.height * UpDown + (Screen.height / 2);
        */
        reticlePosition.x += (LeftRight * speedOfReticle);
        reticlePosition.y += (UpDown * speedOfReticle);      
        this.gameObject.transform.position = reticlePosition;

        //Reticle Size Control
        Vector2 scale = this.GetComponent<RectTransform>().sizeDelta;
        float RightTrigger = (Input.GetAxis("PS4_R2") + 0.1f) * 1000;
        //Debug.Log(Input.GetAxis("PS4_R2"));
        scale.x = 300 - RightTrigger;
        scale.y = 300 - RightTrigger;
        this.GetComponent<RectTransform>().sizeDelta = scale;
    }

    public void FlipOnOff()
    {
        state = !state;
        this.gameObject.SetActive(state);
    }
}
