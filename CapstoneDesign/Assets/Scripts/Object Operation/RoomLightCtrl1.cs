using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLightCtrl1 : MonoBehaviour
{
    bool isOpen;
    GameObject player;
    public GameObject roomLight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            this.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", Color.white);
            roomLight.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        StartCoroutine(LightOff());
    }

    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(3.0f);
        this.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", Color.black);
        roomLight.SetActive(false);
    }
}

