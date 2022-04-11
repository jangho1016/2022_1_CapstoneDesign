using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomFaucet : MonoBehaviour
{
    Animator anim;
    bool isOpen;
    GameObject player;
    public GameObject Water;
    Animation aniUp;
    Animation aniDown;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[35];

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
