using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerSwitch : MonoBehaviour
{
    Animator anim;
    bool isOpen;
    GameObject player;
    public GameObject Water;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[36];

        if (isOpen == true)
        {
            Water.SetActive(true);
            anim.SetBool("isOpen", true);
        }

        else if (isOpen == false)
        {
            Water.SetActive(false);
            anim.SetBool("isOpen", false);
        }
    }
}
