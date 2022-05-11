using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WasherDoor : MonoBehaviour
{
    Animator anim;
    bool isOpen1;
    bool isOpen2;
    bool isOpen3;
    GameObject player;
    public GameObject display;
    string scenename;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        display.GetComponent<MeshRenderer>().materials[0].color = Color.gray;
        
    }

    // Update is called once per frame
    void Update()
    {
        isOpen1 = player.GetComponent<PlayerCtrl>().isOpened[7]; //문이 닫혀 있음
        isOpen2 = player.GetComponent<PlayerCtrl>().isOpened[8]; //서랍이 닫혀 있음
        isOpen3 = player.GetComponent<PlayerCtrl>().isOpened[42]; //버튼 동작
        scenename = player.GetComponent<PlayerCtrl>().curSceneName;

        if (isOpen1 == true)
        {
            anim.SetBool("isOpen", true);
        }
        else if (isOpen1 == false)
        {
            anim.SetBool("isOpen", false);

            if (isOpen2 == false)
            {
                if(isOpen3 == true)
                {
                    if (scenename != "Room 2")
                        display.GetComponent<MeshRenderer>().materials[0].color = Color.red;
                }
                else if (isOpen3 == false)
                {
                    display.GetComponent<MeshRenderer>().materials[0].color = Color.gray;
                }
            }
        }
    }
}
