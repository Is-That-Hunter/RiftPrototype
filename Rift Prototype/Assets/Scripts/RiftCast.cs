using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//THIS MUST BE ON THE STATE MACHINE
public class RiftCast : MonoBehaviour
{
    public GameObject reticle;
    public Camera cam;
    private RiftPoints line;
    private bool riftInitialized;
    Vector3 nothing = new Vector3(0, 0, 0);
    private LineRenderer lineRend;
    private bool downLastFrame;
    private bool upLastFrame;

    // Start is called before the first frame update
    void Start()
    {
        line.start = null;
        line.end = null;
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
        lineRend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerDown = (Input.GetAxis("PS4_R2") >= 0.09); //true if pressed fully
        bool triggerUp = (Input.GetAxis("PS4_R2") <= -0.09); //true if not pressed fully
        Vector3 newRet = reticle.transform.position;
        newRet.x -= Screen.width / 2;
        newRet.y -= Screen.height / 2;
        Ray ray = cam.ScreenPointToRay(reticle.transform.position);
        RaycastHit hitAgain;
        Physics.Raycast(ray, out hitAgain);
        Debug.DrawLine(cam.transform.position, hitAgain.transform.position, Color.green);

        if (triggerDown && riftInitialized)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Rift Point" && line.start == null && !downLastFrame)
            {
                line.start = hit.collider;
                Debug.Log("Setting Line.Start to " + line.start.transform.position);
            }
        }

        if (triggerUp && riftInitialized)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Rift Point" && line.start != null && line.end == null && !upLastFrame)
            {
                line.end = hit.collider;
                Debug.Log("Setting Line.End to " + line.end.transform.position);
            }
            else
            {
                line.end = null;
                line.start = null;
            }
        }

        if(line.start != null && line.end != null && line.start != line.end)
        {
            BuildRift();
        }

        downLastFrame = triggerDown;
        upLastFrame = triggerUp;
    }

    void BuildRift()
    {
        //build shit
        lineRend.enabled = true;
        lineRend.SetPosition(0, line.start.transform.position);
        lineRend.SetPosition(1, line.end.transform.position);
    }

    public void Click()
    {
        riftInitialized = !riftInitialized;
        if(!riftInitialized)
        {
            reticle.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);
            line.start = null;
            line.end = null;
        }
    }

}

public struct RiftPoints
{
    public Collider start;
    public Collider end;
}