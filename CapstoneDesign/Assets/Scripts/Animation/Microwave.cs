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
                display.GetComponent<MeshRenderer>().materials[0].color = new Color(0.137104f, 0.745283f, 0.169763f);
                display.GetComponent<MeshRenderer>().materials[0].SetColor("_EmissionColor", Color.white);
            }
            else if(isOpen2 == false)
            {
                display.GetComponent<MeshRenderer>().materials[0].color = Color.gray;
                display.GetComponent<MeshRenderer>().materials[0].SetColor("_EmissionColor", Color.black);
            }
        }
    }
}
