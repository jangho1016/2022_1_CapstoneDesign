using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaterCtrl : MonoBehaviour
{
    bool isOpen;
    GameObject player;
    public GameObject display;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[34];

        if (isOpen == true)
        {
            display.GetComponent<MeshRenderer>().materials[0].color = new Color(0.137104f, 0.745283f, 0.169763f);
        }
        else if (isOpen == false)
        {
            display.GetComponent<MeshRenderer>().materials[0].color = Color.gray;
        }
    }
}
