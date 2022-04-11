using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaterSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip test;
    bool isOpen;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[34];
        audioSource.clip = test;

        if (isOpen == true)
        {
            this.audioSource.Play();

            if((this.audioSource.isPlaying) == true)
            {
                Debug.Log("com");
            }
        }
        else if (isOpen == false)
        {
            this.audioSource.Stop();
        }
    }
}
