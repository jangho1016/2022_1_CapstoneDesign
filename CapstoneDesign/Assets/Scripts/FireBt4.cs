using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBt4 : MonoBehaviour
{
    bool isOpen;
    GameObject player;
    public GameObject fire;
    string scenename;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[46];
        scenename = player.GetComponent<PlayerCtrl>().curSceneName;

        if (isOpen == true)
        {
            if(scenename != "Room3")
                fire.SetActive(true);
        }
        else if (isOpen == false)
        {
            fire.SetActive(false);
        }
    }
}
