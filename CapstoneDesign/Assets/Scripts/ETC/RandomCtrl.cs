using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomCtrl : MonoBehaviour
{
    private int randn;

    // Start is called before the first frame update
    void Start()
    {
        randn = Random.Range(1, 6); //랜덤을 1-5까지 돌림
        PlayerPrefs.SetInt("rand_num", randn); //랜덤값을 저장해줌
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Map Select Scene");
    }
}
