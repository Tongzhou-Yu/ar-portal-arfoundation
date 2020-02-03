using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField]
   // private Button DoorToggle;

    void Awake()
    {
    
        //DoorToggle.onClick.AddListener(OpenClose);

    }

    public void OpenClose()
    {
        Animator anim = this.GetComponentInChildren<Animator>();
        anim.SetTrigger("OpenClose");
    }

}
