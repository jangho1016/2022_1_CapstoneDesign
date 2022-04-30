using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InformationText : MonoBehaviour
{
    public Text nText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Narration());
    }

    IEnumerator Narration()
    {
        nText.text = "";
        nText.DOText("조작법\n이동: 카드보드 자석 버튼 사용\n상호작용: 커서게이지를 이용하여 해당 물체를 응시\n\n진행 과정\n하자 없는 방을 찾게 되면 계약 사항 관련 퀴즈로 넘어가며 그 후 360도로 촬영된 실제 방을 보며 배운 것을 복습", 10.0f);
        yield return new WaitForSeconds(10.0f);
    }
}
