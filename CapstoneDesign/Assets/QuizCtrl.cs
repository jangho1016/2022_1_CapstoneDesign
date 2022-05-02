using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuizCtrl : MonoBehaviour
{
    public GameObject bt1;
    public GameObject bt2;
    public GameObject bt3;
    public GameObject bt4;
    public Text text;
    public Text qText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Quest1());
    }

    IEnumerator Quest1()
    {
        qText.text = "";
        qText.DOText("1. 주택에 관한 등기부등본의 설명으로 옳은 것은?\n\n(1) 201호의 공동 주택의 경우 201호로 등기부등본을 발급받을 수 있다.\n(2) 단독주택이라면 201호로 등기부등본을 발급받을 수 있다.\n(3) 다가구 주택은 각 호 마다 구분 등기가 되어 있다.\n(4) 다세대 주택은 단독주택이므로 등기가 하나이다.", 10.0f);
        yield return new WaitForSeconds(10.0f);

        text.text = "";
        text.DOText("정답을 고르시오", 2.0f);
        yield return new WaitForSeconds(2.0f);


        bt1.SetActive(true);
        bt2.SetActive(true);
        bt3.SetActive(true);
        bt4.SetActive(true);
    }
}
