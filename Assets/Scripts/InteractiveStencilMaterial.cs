using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InteractiveStencilMaterial : MonoBehaviour
{
    bool inOtherWorld;
    void Start()
    {
        SetMaterials(false);
    }

    void SetMaterials(bool fullRender)
    {
        var stencilTest = fullRender ? CompareFunction.Always : CompareFunction.Equal;
        this.GetComponent<MeshRenderer>().material.SetInt("_StencilComp", (int)stencilTest);

    }

    private void OnTriggerEnter(Collider collider)
    {
        //the tag of Portal Gameobject need to be set as Portal 
        if(collider.tag == "Portal") 
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
        }
    }


    private void OnDestroy()
    {
        SetMaterials(true);
    }


}
