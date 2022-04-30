using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomFaucet : MonoBehaviour
{
    Animator anim;
    bool isOpen1;
    bool isOpen2;
    GameObject player;
    public GameObject water;
    public GameObject water1;
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
        isOpen2 = player.GetComponent<PlayerCtrl>().isOpened[35]; //수도
        scenename = player.GetComponent<PlayerCtrl>().curSceneName;

        //1. 보일러 킨 상태에서 물 켤때 (연기 생겨야됨)
        //2. 보일러 끈 상태에서 물 켤때 (연기 없어야됨)
        //3. 물 킨 상태에서 보일러 끌때 (연기 사라져야됨)
        //4, 물 킨 상태에서 보일러 킬때 (연기 생겨야됨)
        //5. 물 끈 상태에서 보일러 킬때 (연기 없어야됨)
        //6. 그냥 물 끌때 (연기 사라져야됨)

        if (isOpen2 == true) //물 킨 상태
        {
            water.SetActive(true);
            anim.SetBool("isOpen", true);
            if (scenename == "Room3")
            {
                water.GetComponent<MeshRenderer>().materials[0].color = new Color(0.9811321f, 0.8250644f, 0.495194f);
                water1.GetComponent<MeshRenderer>().materials[0].color = new Color(0.9811321f, 0.8250644f, 0.495194f);
            }

            if (isOpen1 == true) //보일러 킬때
            {
                if(scenename != "Room4")
                    StartCoroutine(SmokeCtrlOn());
            }
            else if(isOpen1 == false) //보일러 끌때
            {
                StartCoroutine(SmokeCtrlOff());
            }
        }

        else if (isOpen2 == false)
        {
            water.SetActive(false);
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
