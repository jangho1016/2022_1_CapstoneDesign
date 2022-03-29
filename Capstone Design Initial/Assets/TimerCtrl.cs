using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCtrl : MonoBehaviour
{
    public Text timertext;
    private float timer;
    private float time_last;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //타이머
        timer += Time.deltaTime;

        time_last = 300.0f - timer;

        timertext.text = "남은 시간 : " + ((int)(time_last / 60) + "분" + (int)(time_last % 60) + "초");

        if (time_last <= 60.0f)
        {
            timertext.text = "남은 시간 : " + (int)(time_last % 60) + "초";
        }
    }
}
