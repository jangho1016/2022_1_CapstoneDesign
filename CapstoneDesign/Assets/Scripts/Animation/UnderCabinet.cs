using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderCabinet : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    private bool isOpen = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(this.gameObject.CompareTag("UnderCabinetL"))
        {
            isOpen = player.GetComponent<PlayerCtrl>().isOpened[50];
        }
        else if(this.gameObject.CompareTag("UnderCabinetR"))
        {
            isOpen = player.GetComponent<PlayerCtrl>().isOpened[51];
        }

        if (isOpen == true) anim.SetBool("isOpen", true); 
        else anim.SetBool("isOpen", false);
    }
}
