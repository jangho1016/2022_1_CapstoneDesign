using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirConditioner : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip bgm;
    bool isOpen;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[41];
        audioSource.clip = bgm;

        if (isOpen == true)
        {
            Debug.Log(audioSource.clip.name);
            audioSource.Play();
        }
        else if (isOpen == false)
        {
            audioSource.Stop();
        }
    }
}
