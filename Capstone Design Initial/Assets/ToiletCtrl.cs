using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletCtrl : MonoBehaviour
{
    //Animator anim;
    private Animation anim;
    bool isOpen;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        anim.wrapMode = WrapMode.Once;
        anim.Play();
    }
}
