using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch1 : MonoBehaviour
{
    Animator anim;
    bool isOpen;
    GameObject player;
    public GameObject roomLight;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[25];

        if (isOpen == true)
        {
            roomLight.SetActive(true);
            anim.SetBool("isOpen", true);
        }
        else if (isOpen == false)
        {
            roomLight.SetActive(false);
            anim.SetBool("isOpen", false);
        }
    }
}
