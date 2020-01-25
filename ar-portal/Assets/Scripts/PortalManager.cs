// (c) 2020 Tongzhou Yu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{

    public GameObject InnerWorld;

    //This materials matter needs to be optimizated!
    public Material[] materials;

    private Vector3 camPostionInPortalSpace;

    bool wasInFront;
    bool inOtherWorld;

    // Start is called before the first frame update
    void Start()
    {

        SetMaterials(false);

    }

    void SetMaterials(bool fullRender)
    {
        var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;

        foreach (var mat in materials)
        {
            mat.SetInt("_StencilComp", (int)stencilTest);
        }
    }

    //Set bidirectional function
    bool GetIsInFront()
    {
        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camPostionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);
        return camPostionInPortalSpace.y >= 0.01 ? true : false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (collider.transform != MainCamera.transform)
            return;
        wasInFront = GetIsInFront();

    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (collider.transform != MainCamera.transform)
            return;
        bool isInFront = GetIsInFront();
        if ((isInFront && !wasInFront) || (wasInFront && !isInFront))
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
        }
        wasInFront = isInFront;

    }

    private void OnDestroy()
    {
        SetMaterials(true);
    }

}
