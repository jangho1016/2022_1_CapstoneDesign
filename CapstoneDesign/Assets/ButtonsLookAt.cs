﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsLookAt : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player);
    }
}
