using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveSound : MonoBehaviour
{
    public AudioSource audioSource;
    bool isOpen;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[42];

        if (isOpen == true)
        {
            audioSource.Play();
        }
        else if (isOpen == false)
        {
            audioSource.Stop();
        }
    }
}
