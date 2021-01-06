using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDoorController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        OpenClose();
    }

        public void OpenClose()
    {
        Animator anim = this.GetComponentInChildren<Animator>();
        anim.SetTrigger("OpenClose");
    }

}
