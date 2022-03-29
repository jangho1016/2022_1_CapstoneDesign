using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Replay", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
