using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCtrl : MonoBehaviour
{
    public Text timertext;
    private float timer;
    public float time_last;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //타이머 시작

        time_last = 15.0f - timer; //타이머 제한 시간 설정 (초 - 타이머)

        timertext.text = "남은 시간 : " + ((int)(time_last / 60) + "분" + (int)(time_last % 60) + "초"); //남은 시간 표시

        if (time_last <= 60.0f)
        {
            timertext.text = "남은 시간 : " + (int)(time_last % 60) + "초"; //1분 미만일 때 타이머 표시
        }
    }
}
