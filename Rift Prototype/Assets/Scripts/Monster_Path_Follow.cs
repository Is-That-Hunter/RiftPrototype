using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Monster_Path_Follow : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTraveled;

    private void Update()
    {
        distanceTraveled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Platform Time");
        }
    }
}
