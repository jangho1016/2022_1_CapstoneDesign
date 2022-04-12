using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBt3 : MonoBehaviour
{
    bool isOpen;
    GameObject player;
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[45];

        if (isOpen == true)
        {
            fire.SetActive(true);
        }
        else if (isOpen == false)
        {
            fire.SetActive(false);
        }
    }
}
