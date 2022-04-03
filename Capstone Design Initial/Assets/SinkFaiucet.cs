using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkFaiucet : MonoBehaviour
{
    Animator anim;
    bool isOpen;
    GameObject player;
    public GameObject Water;
    Animation aniUp;
    Animation aniDown;
    float a;
    float b;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        //a = aniUp.GetComponent<Animation>().transform.localPosition.y;
        //b = aniDown.GetComponent<Animation>().transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[33];

        if (isOpen == true)
        {
            Water.SetActive(true);
            anim.SetBool("isOpen", true);
            //
            //
        }

        else if (isOpen == false)
        {
            b = a;
            Water.SetActive(false);
            anim.SetBool("isOpen", false);
        }
    }
}
