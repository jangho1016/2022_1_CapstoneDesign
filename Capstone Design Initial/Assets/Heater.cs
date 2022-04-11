
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : MonoBehaviour
{
    bool isOpen;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().materials[0].color = Color.gray;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[34];

        if (isOpen == true)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.green;
        }
        else if (isOpen == false)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.gray;
        }
    }
}
