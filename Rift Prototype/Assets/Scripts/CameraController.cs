using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assume Camera is negitavely away on the z axis and follows on the x access
public class CameraController : MonoBehaviour
{
    public Transform targetTransform;
    public float HorizontalDelta = 1.25f; //How far the player can move left and right from the camera
    public float distanceClose = 14; //How close the player gets to the camera
    public float distanceFar = 20; //How far the player can get away from the camera
    public float verticalDelta = 2; //When the camera needs to follow the player vertically
    public float smoothCamera = 0.35f; //Smoothness of Camera
    private Vector3 velocity = Vector3.zero;

    Vector3 tempVec3 = Vector3.zero;

    void LateUpdate() {
        Vector3 tempVec3 = this.transform.position;
        //Distance Left or Right from Camera
        if(tempVec3.x - targetTransform.position.x > HorizontalDelta)
        {
            tempVec3.x = targetTransform.position.x + HorizontalDelta;
        }
        if(tempVec3.x - targetTransform.position.x < -HorizontalDelta)
        {
            tempVec3.x = targetTransform.position.x - HorizontalDelta;
        }
        //Distance Close or Away to/from Camera
        if(Mathf.Abs(tempVec3.z - targetTransform.position.z) < distanceClose)
        {
            tempVec3.z = targetTransform.position.z - distanceClose;
        }
        else if(Mathf.Abs(tempVec3.z - targetTransform.position.z) > distanceFar)
        {
            tempVec3.z = targetTransform.position.z - distanceFar;
        }
        this.transform.position = Vector3.SmoothDamp(transform.position, tempVec3, ref velocity, smoothCamera);
    }
}
