using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingText : MonoBehaviour
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
        nText.DOText("로딩중입니다.....", 3.0f);
        yield return new WaitForSeconds(3.0f);
    }
}
