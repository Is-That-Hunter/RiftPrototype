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

    // Start is called before the first frame update
    void Start()
    {
        line.start = nothing;
        line.end = nothing;
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

        if (triggerDown && riftInitialized)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Rift Point" && line.start == nothing)
            {
                line.start = hit.transform.position;
            }
        }

        if (triggerUp && riftInitialized)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Rift Point" && line.start != nothing && line.end == nothing)
            {
                line.end = hit.transform.position;
            }
            else
            {
                line.end = nothing;
                line.start = nothing;
            }
        }

        if(line.start != nothing && line.end != nothing && line.start != line.end)
        {
            BuildRift();
        }
    }

    void BuildRift()
    {
        Debug.Log("You made a line from " + line.start + " to " + line.end);

        //build shit
        lineRend.enabled = true;
        lineRend.SetPosition(0, line.start);
        lineRend.SetPosition(1, line.end);


        line.start = nothing;
        line.end = nothing;
    }

    public void Click()
    {
        riftInitialized = !riftInitialized;
        if(!riftInitialized)
        {
            reticle.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);
            line.start = nothing;
            line.end = nothing;
        }
    }

}

public struct RiftPoints
{
    public Vector3 start;
    public Vector3 end;
}