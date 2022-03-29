using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCtrl : MonoBehaviour
{
    private int rand_num;

    // Start is called before the first frame update
    void Start()
    {
        rand_num = Random.Range(1, 6);
        PlayerPrefs.SetInt("rand_num", rand_num);
        Debug.Log(PlayerPrefs.GetInt("rand_num"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
