using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InteractiveStencilMaterial : MonoBehaviour
{
    bool inOtherWorld;
    bool hasTriggered;

    void Start()
    {
        SetMaterials(false);
        Debug.Log(hasTriggered);
    }

    void SetMaterials(bool fullRender)
    {
        var stencilTest = fullRender ? CompareFunction.Always : CompareFunction.Equal;
        this.GetComponent<MeshRenderer>().material.SetInt("_StencilComp", (int)stencilTest);

    }

    private void OnTriggerEnter(Collider portal)
    {
        //the tag of Portal Gameobject need to be set as Portal 
        if(hasTriggered == false && portal.tag == "Portal") 
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
            Debug.Log(hasTriggered);
        }
    }

    private void OnTriggerExit(Collider portal)
    {
        if(portal.tag == "Portal")
        {
            if(hasTriggered == true)
            {
                inOtherWorld = !inOtherWorld;
                SetMaterials(inOtherWorld);
            }
            hasTriggered = !hasTriggered;
            Debug.Log(hasTriggered);
        }
    }


    private void OnDestroy()
    {
        SetMaterials(true);
    }


}
