using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLightCtrl3 : MonoBehaviour
{
    bool isOpen;
    GameObject player;
    public GameObject roomLight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[49];

        if (isOpen == true)
        {
            this.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", Color.white);
            roomLight.SetActive(true);
        }
        else if (isOpen == false)
        {
            this.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", Color.black);
            roomLight.SetActive(false);
        }
    }
}
