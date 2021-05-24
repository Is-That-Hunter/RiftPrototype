using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlatTransitionAnimation : MonoBehaviour
{
    public float initialSize = 1f;
    public float currSize = 1f;
    public float maxSize = 120f;
    public float rotatePickup = .5f;
    public float rotateCurrSpeed;
    public float rotateMaxSpeed = 7f;
    public float expansionRate = 1f;
    public float timeScale = 0.0f;
    
    public bool spinSpanding = false;
    public bool done = false;

    void Update()
    {
        if(spinSpanding && !done)
        {
            currSize += expansionRate *Time.deltaTime;
            //float nextSize = expansionRate*currSize;
            if(currSize > maxSize)
            {
                done = true;
            }
            this.transform.localScale = new Vector3(currSize, currSize, currSize);
            if(rotateCurrSpeed < rotateMaxSpeed)
                rotateCurrSpeed += rotatePickup * Time.deltaTime;
        }
        if(rotateCurrSpeed > rotateMaxSpeed)
            rotateCurrSpeed = rotateMaxSpeed;
        this.transform.Rotate(0f,0f,rotateCurrSpeed);
    }

    void changeActive(bool active) {
        if(active) {
            this.transform.localScale = new Vector3(initialSize, initialSize, initialSize);
            this.rotateCurrSpeed = 0.0f;
            spinSpanding = true;
            done = false;
        }
    }
}
