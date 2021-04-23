using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Monster_Path_Follow : MonoBehaviour
{
    public PathCreator pathCreator;
    public Animator anim;
    public float speed = 5;
    float distanceTraveled;

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
        //Debug.Log(pathCreator.path.GetPointAtDistance(distanceTraveled));
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
        //Debug.Log(pathCreator.path.GetClosestPointOnPath(transform.position));
        compVect = transform.position - prevVect;
        //Debug.Log(transform.position);
        //Debug.Log(compVect);
        anim.SetFloat("horizontalMove", compVect.x * 100);
        anim.SetFloat("verticalMove", compVect.z * 100);
        if(Mathf.Abs(compVect.z) > Mathf.Abs(compVect.x))
        {
            anim.SetBool("currentVert", true);
        }
        else
        {
            anim.SetBool("currentVert", false);
        }
        prevVect = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Platform Time");
        }
    }
}
