using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assume Camera is negitavely away on the z axis and follows on the x access
public class CameraController : MonoBehaviour
{
    public Transform focusObject;
    public Transform mainCharacter;
    public float HorizontalDelta = 1; //How far the player can move left and right from the camera
    public float distanceClose = 10; //How close the player gets to the camera
    public float distanceFar = 15; //How far the player can get away from the camera
    public float verticalHeight = 4; //When the camera needs to follow the player vertically
    public float smoothCamera = 0.35f; //Smoothness of Camera
    public bool zoomIn = false;
    public bool focus = false;
    private Vector3 velocity = Vector3.zero;

    Vector3 tempVec3 = Vector3.zero;

    void LateUpdate() {
        Vector3 tempVec3 = this.transform.position;
        Transform target = mainCharacter;
        if(focus)
            target = focusObject;

        //Distance Left or Right from Camera
        tempVec3.x = changeX(HorizontalDelta, target);
        //Distance Close or Away to/from Camera
        if(zoomIn) {
            tempVec3.z = changeZ(4, 5, target);
            tempVec3.y = target.position.y;
        }
        else {
            tempVec3.z = changeZ(distanceClose, distanceFar, target);
            tempVec3.y = target.position.y+verticalHeight;
        }
        
        this.transform.position = Vector3.SmoothDamp(transform.position, tempVec3, ref velocity, smoothCamera);
        DontDestroyOnLoad(this.gameObject);
    }
    private float changeZ(float close, float far, Transform target) {
        float z = target.position.z;
        if(Mathf.Abs(z - target.position.z) < close)
        {
            z = target.position.z - close;
        }
        else if(Mathf.Abs(z - target.position.z) > far)
        {
            z = target.position.z - far;
        }
        return z;
    }
    private float changeX(float delta, Transform target) {
        float x = target.position.x;
        if(x - target.position.x > delta)
        {
            x = target.position.x + delta;
        }
        if(x - target.position.x < -delta)
        {
            x = target.position.x - delta;
        }
        return x;
    }
}
