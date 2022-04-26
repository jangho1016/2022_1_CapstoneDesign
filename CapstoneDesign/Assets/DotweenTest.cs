using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DotweenTest : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Test()
    {
        text.text = "";
        text.DOText("test", 3.0f);

        yield return new WaitForSeconds(1.0f);
    }
}
