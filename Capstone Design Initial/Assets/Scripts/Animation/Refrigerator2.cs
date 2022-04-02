using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator2 : MonoBehaviour
{
    Animator anim;
    bool isOpen;
    GameObject player;
    bool refriDcheckDown;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[19];
        refriDcheckDown = player.GetComponent<PlayerCtrl>().refriDcheckDown;

        if (isOpen == true)
        {
            anim.SetBool("isOpen", true);
        }
        else if (isOpen == false && (refriDcheckDown == false))
        {
            anim.SetBool("isOpen", false);
        }
    }
}
