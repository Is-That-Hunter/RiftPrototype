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

    public bool opaque = false;

    //keeps track of seconds passed
    private float timer;

    //shows current state of the object
    private bool fadingIn;
    private bool fadingOut;
    private bool solid;
    private bool gone;
    private Renderer rend;

    //The speed at which the gameObject dissapears;
    //private float speed;

    public enum BlendMode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent
    }

    public static void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                break;
            case BlendMode.Cutout:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 2450;
                break;
            case BlendMode.Fade:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
            case BlendMode.Transparent:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
        }

    }

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        fadingIn = false;
        fadingOut = false;
        gone = false;
        solid = true;
        timer = timeSolid;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.GetComponent<MeshRenderer>().material.color.a);
        if (solid)
        {
            if (!opaque)
            {
                ChangeRenderMode(rend.material, BlendMode.Opaque);
                opaque = true;
            }
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                solid = false;
                fadingOut = true;
                timer = timeFadingOut;
            }
        } else if (fadingOut)
        {
            if (opaque)
            {
                ChangeRenderMode(rend.material, BlendMode.Fade);
                opaque = false;
            }
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
