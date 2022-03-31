using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveDoorCtrl : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("MicrowaveDoor") == 1)
        {
            anim.SetBool("isOpen", true);
        }
        else if (PlayerPrefs.GetInt("MicrowaveDoor") == 0)
        {
            anim.SetBool("isOpen", false);
        }
    }
}
