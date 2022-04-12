using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerSwitch : MonoBehaviour
{
    Animator anim;
    bool isOpen;
    GameObject player;
    public GameObject Water;
    public GameObject ShowerWater;

    // Start is called before the first frame update
    void Start()
    {
        anim = Water.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[36];

        if (isOpen == true)
        {
            ShowerWater.SetActive(true);
            anim.SetBool("isOpen", true);
        }

        else if (isOpen == false)
        {
            ShowerWater.SetActive(false);
            anim.SetBool("isOpen", false);
        }
    }
}
