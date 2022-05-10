using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InformationText : MonoBehaviour
{
    public Text nText;
    public GameObject mainButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Narration());
    }

    IEnumerator Narration()
    {
        nText.text = ""; //텍스트 초기화
        nText.DOText("조작법\n이동: 카드보드 자석 버튼 사용\n상호작용: 커서게이지를 이용하여 해당 물체를 3초간 응시\n\n진행 과정\n지도에서 보고싶은 방 선택 후 하자가 없는 방이나 모든 하자를 찾은 뒤 부동산중개업자와 상호작용하여 버튼을 이용합니다. 그 후 퀴즈를 맞추고 실제 방과 화장실을 둘러보면 됩니다.\n\n\n\n", 10.0f);
        yield return new WaitForSeconds(10.0f);

        mainButton.SetActive(true);
    }
}
