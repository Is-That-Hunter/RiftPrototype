using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Camera_Path_Follow : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 0;
    public CameraController otherCam;
    float distanceTraveled;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public EndOfPathInstruction end;

    public bool pathFinished = false;

    Vector3 prevVect;
    Vector3 compVect;

    private void Start()
    {
        prevVect = transform.position;
        compVect = transform.position - transform.position;
    }

    private void Update()
    {
        distanceTraveled += speed * Time.deltaTime;
        Vector3 targetPosition = pathCreator.path.GetPointAtDistance(distanceTraveled, end);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, pathCreator.path.GetRotationAtDistance(distanceTraveled, end), smoothTime);
        compVect = transform.position - prevVect;
        prevVect = transform.position;
        if(!pathFinished && distanceTraveled > 365) {
            otherCam.GetComponent<Camera>().enabled=true;
            otherCam.skyCamStatus = 2;
            otherCam.globalData.overlay.changePromptActive(false);
            otherCam.globalData.releaseTheStates();
            Destroy(this.gameObject);
        }
    }
}
