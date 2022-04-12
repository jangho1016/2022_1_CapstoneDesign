using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirconditionerCtrl : MonoBehaviour
{
    bool isOpen;
    GameObject player;
    public GameObject display;

    // Start is called before the first frame update
    void Start()
    {
        display.GetComponent<MeshRenderer>().materials[0].color = Color.gray;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[47];

        if (isOpen == true)
        {
            display.GetComponent<MeshRenderer>().materials[0].color = Color.red;
        }
        else if (isOpen == false)
        {
            display.GetComponent<MeshRenderer>().materials[0].color = Color.gray;
        }
    }
}
