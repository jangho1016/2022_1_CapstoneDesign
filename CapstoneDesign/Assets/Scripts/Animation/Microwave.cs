using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour
{
    Animator anim;
    bool isOpen1;
    bool isOpen2;
    GameObject player;
    public GameObject display;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        display.GetComponent<MeshRenderer>().materials[0].color = Color.gray;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen1 = player.GetComponent<PlayerCtrl>().isOpened[3];
        isOpen2 = player.GetComponent<PlayerCtrl>().isOpened[4];

        if (isOpen1 == true)
        {
            anim.SetBool("isOpen", true);
        }
        else if (isOpen1 == false)
        {
            anim.SetBool("isOpen", false);
            
            if(isOpen2 == true)
            {
                display.GetComponent<MeshRenderer>().materials[0].color = Color.red;
            }
            else if(isOpen2 == false)
            {
                display.GetComponent<MeshRenderer>().materials[0].color = Color.gray;
            }
        }
    }
}
