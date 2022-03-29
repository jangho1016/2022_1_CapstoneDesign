using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCtrl : MonoBehaviour
{
    private int rand_num;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Replay") == 0)
        {
            rand_num = Random.Range(1, 6); //랜덤을 1-5까지 돌림
            PlayerPrefs.SetInt("rand_num", rand_num); //랜덤값을 저장해줌
            //Debug.Log(PlayerPrefs.GetInt("rand_num"));
        }
    }
}
