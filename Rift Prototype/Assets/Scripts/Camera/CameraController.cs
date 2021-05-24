using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Assume Camera is negitavely away on the z axis and follows on the x access
public class CameraController : MonoBehaviour
{
    //For Dialogue
    public Transform focusObject;
    public GlobalData globalData;
    //For Trigggers
    public ZoomTarget focusObj;
    public Transform mainCharacter;
    public Camera_Path_Follow skyCam;
    public int skyCamStatus = 0;
    public float HorizontalDelta = 1; //How far the player can move left and right from the camera
    public float distanceClose = 10; //How close the player gets to the camera
    public float distanceFar = 15; //How far the player can get away from the camera
    public float verticalHeight = 4; //When the camera needs to follow the player vertically
    public float smoothCamera = 0.35f; //Smoothness of Camera
    public bool zoomIn = false;
    public bool focus = false;
    public bool focusOther = false;
    public Vector3 velocity = Vector3.zero;
    public bool waitforslow = false;

    Vector3 tempVec3 = Vector3.zero;
    void Start() {
    }

    void LateUpdate() {
        if(skyCamStatus == 1 && !skyCam.pathFinished)
        {
            globalData.overlay.forceChangePromptActive(true);
            globalData.noTopState();
        }
        if(skyCamStatus == 0 && waitforslow)
        {   
            Camera_Path_Follow[] cams = GameObject.FindObjectsOfType<Camera_Path_Follow>();
            if(cams.Length != 0)
            {
                skyCam = cams.First();
                gameObject.GetComponent<Camera>().enabled = false;
                skyCam.GetComponent<Camera>().enabled = true;
                skyCam.otherCam = this;
                skyCam.speed = 20;
                skyCamStatus = 1;
                waitforslow = false;
                globalData.overlay.changePrompt("Press Any Key to Skip Cutscene");
                globalData.overlay.changePromptActive(true);
                
            }
            return;
        }
        Vector3 tempVec3 = this.transform.position;
        Transform target = mainCharacter;
        if(focus)
        {
            target = focusObject;
        }
        if(focusOther)
        {
            if(focusObj != null)
            {
                if(focusObj.search())
                    target = focusObj.target.transform;
            }
        }
            
        
        float targetHorizontal = target.position.x;
        float targetDistance = target.position.z;
        //Distance Left or Right from Camera
        tempVec3.x = changeHorizontal(HorizontalDelta, targetHorizontal);
        //Distance Close or Away to/from Camera
        if(zoomIn) {
            tempVec3.z = changeDistance(4, 5, targetDistance);
            tempVec3.y = target.position.y;
        }
        else {
            tempVec3.z = changeDistance(distanceClose, distanceFar, targetDistance);
            tempVec3.y = target.position.y+verticalHeight;
        }

        if(waitforslow)
        {
            this.transform.position = Vector3.SmoothDamp(transform.position, tempVec3, ref velocity, .20f);
            if(Mathf.Abs(velocity.x) < .01f && Mathf.Abs(velocity.y) < .01f && Mathf.Abs(velocity.z) < .01f)
                waitforslow = false;
        }
        else {
            this.transform.position = Vector3.SmoothDamp(transform.position, tempVec3, ref velocity, smoothCamera);
        }
        
    }
    private float changeDistance(float close, float far, float targetDistance) {
        float z = targetDistance;
        if(Mathf.Abs(z - targetDistance) < close)
        {
            z = targetDistance - close;
        }
        else if(Mathf.Abs(z - targetDistance) > far)
        {
            z = targetDistance - far;
        }
        return z;
    }
    private float changeHorizontal(float delta, float targetHorizontal) {
        float x = targetHorizontal;
        if(x - targetHorizontal > delta)
        {
            x = targetHorizontal + delta;
        }
        if(x - targetHorizontal < -delta)
        {
            x = targetHorizontal - delta;
        }
        return x;
    }
}
