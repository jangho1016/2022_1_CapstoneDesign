using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("rand_num", 0); //랜덤 숫자 초기화
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
