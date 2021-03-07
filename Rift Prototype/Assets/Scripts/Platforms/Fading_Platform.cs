using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading_Platform : MonoBehaviour
{
    //time in seconds for each state
    public float timeSolid = 0;
    public float timeFadingOut = 0;
    public float timeFadingIn = 0;
    public float timeGone = 0;

    //keeps track of seconds passed
    private float timer;

    //shows current state of the object
    private bool fadingIn;
    private bool fadingOut;
    private bool solid;
    private bool gone;

    //The speed at which the gameObject dissapears;
    //private float speed;

    void Start()
    {
        fadingIn = false;
        fadingOut = false;
        gone = false;
        solid = true;
        timer = timeSolid;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.GetComponent<MeshRenderer>().material.color.a);
        if (solid)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                solid = false;
                fadingOut = true;
                timer = timeFadingOut;
            }
        } else if (fadingOut)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Color color = gameObject.GetComponent<MeshRenderer>().material.color;
                color.a = 0;
                gameObject.GetComponent<MeshRenderer>().material.color = color;

                gameObject.GetComponent<BoxCollider>().enabled = false;
                fadingOut = false;
                gone = true;
                timer = timeGone;
            }
            else
            {
                Color color = gameObject.GetComponent<MeshRenderer>().material.color;
                color.a = timer / timeFadingOut;
                gameObject.GetComponent<MeshRenderer>().material.color = color;
            }
        } else if (gone)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                gone = false;
                fadingIn = true;
                timer = timeFadingIn;
            }
        } else if (fadingIn)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                Color color = gameObject.GetComponent<MeshRenderer>().material.color;
                color.a = 1;
                gameObject.GetComponent<MeshRenderer>().material.color = color;

                fadingIn = false;
                solid = true;
                timer = timeSolid;
            }
            else
            {
                Color color = gameObject.GetComponent<MeshRenderer>().material.color;
                color.a = (1 - (timer / timeFadingIn));
                gameObject.GetComponent<MeshRenderer>().material.color = color;
            }
        }
    }

    /*private void FixedUpdate()
    {
        if (fading)
        {

        }
    }*/
}
