using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WindowAnim : MonoBehaviour
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
        if (PlayerPrefs.GetInt("window") == 1)
        {
            anim.SetBool("isOpen", true);
        }
        else if (PlayerPrefs.GetInt("window") == 0)
        {
            anim.SetBool("isOpen", false);
        }
    }
}
