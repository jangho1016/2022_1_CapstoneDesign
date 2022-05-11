using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkFaiucet : MonoBehaviour
{
    Animator anim;
    bool isOpen1;
    bool isOpen2;
    GameObject player;
    public GameObject Water;
    public GameObject Smoke;
    string scenename;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen1 = player.GetComponent<PlayerCtrl>().isOpened[34]; //보일러
        isOpen2 = player.GetComponent<PlayerCtrl>().isOpened[33]; //수도

        scenename = player.GetComponent<PlayerCtrl>().curSceneName;

        if (isOpen2 == true) //물 킨 상태
        {
            Water.SetActive(true);
            anim.SetBool("isOpen", true);

            if (isOpen1 == true) //보일러 킬때
            {
                if (scenename != "Room 4")
                    StartCoroutine(SmokeCtrlOn());
            }
            else if (isOpen1 == false) //보일러 끌때
            {
                StartCoroutine(SmokeCtrlOff());
            }
        }

        else if (isOpen2 == false)
        {
            Water.SetActive(false);
            anim.SetBool("isOpen", false);
            StartCoroutine(SmokeCtrlOff());
        }
    }

    IEnumerator SmokeCtrlOn()
    {
        yield return new WaitForSeconds(1.0f);
        Smoke.SetActive(true);
    }

    IEnumerator SmokeCtrlOff()
    {
        yield return new WaitForSeconds(1.0f);
        Smoke.SetActive(false);
    }
}
