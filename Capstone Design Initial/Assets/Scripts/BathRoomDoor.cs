using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathRoomDoor : MonoBehaviour
{
    Animator anim;
    bool isOpen;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[1];

        if (isOpen == true)
        {
            anim.SetBool("isOpen", true);
        }
        else if (isOpen == false)
        {
            anim.SetBool("isOpen", false);
        }
    }
}
