using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitchCtrl1 : MonoBehaviour
{
    string test;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        test = this.gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(test);
        if (PlayerPrefs.GetInt("RoomSwitch1") == 1)
        {
            anim.SetBool("isOpen", true);
        }
        else if (PlayerPrefs.GetInt("RoomSwitch1") == 0)
        {
            anim.SetBool("isOpen", false);
        }
    }
}
