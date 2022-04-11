using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomSwitch1 : MonoBehaviour
{
    Animator anim;
    bool isOpen;
    GameObject player;
    public GameObject bathLight;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[31];

        if (isOpen == true)
        {
            bathLight.SetActive(true);
            anim.SetBool("isOpen", true);
        }
        else if (isOpen == false)
        {
            bathLight.SetActive(false);
            anim.SetBool("isOpen", false);
        }
    }
}
