using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public Image cursorGauge;
    public GameObject mainCam;
    private float GaugeTimer = 0.0f;
    private float gazeTimer = 2.0f;
    private float positionY;
    private string curSceneName;
    private GameObject obj;
    private GameObject floor;
    private int cnt = 0;
    private Vector3 ScreenCenter;
    //

    void Start()
    {
        PlayerPrefs.SetInt("SceneNum", 0);

        Debug.Log(SceneManager.GetActiveScene().name);
        curSceneName = SceneManager.GetActiveScene().name;

        if (curSceneName == "Room")
        {
            PlayerPrefs.SetInt("SceneNum", 1);
        }
        else if (curSceneName == "Room1")
        {
            PlayerPrefs.SetInt("SceneNum", 3);
        }
        else
        {
            PlayerPrefs.SetInt("SceneNum", 0);
        }

        //Debug.Log(PlayerPrefs.GetInt("SceneNum"));
        obj = GameObject.FindGameObjectWithTag("obj");
        //floor = GameObject.FindGameObjectWithTag("Floor");
    }

    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("SceneNum"));
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 1000;
        cursorGauge.fillAmount = GaugeTimer;

        Debug.DrawRay(transform.position, forward, Color.red);

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            GaugeTimer += 1.0f / gazeTimer * Time.deltaTime;

            if (hit.transform.tag == "Untagged")
            {
                GaugeTimer = 0.0f;
            }

            else if (GaugeTimer >= 1.0f)
            {
                if (PlayerPrefs.GetInt("SceneNum") == 0)
                {
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                }
                else if (PlayerPrefs.GetInt("SceneNum") == 1)
                {
                    if(hit.transform.CompareTag("obj") || hit.transform.CompareTag("obj1"))
                    {
                        hit.transform.gameObject.SetActive(false);
                        cnt++;

                        if(cnt >= 2)
                        {
                            SceneManager.LoadScene("Real Room2");
                        }
                    }
                }
                else if (PlayerPrefs.GetInt("SceneNum") == 3)
                {
                        hit.transform.gameObject.SetActive(false);
                }
                GaugeTimer = 0.0f;
            }
        }
        else
            GaugeTimer = 0.0f;

        if (PlayerPrefs.GetInt("SceneNum") == 1 || PlayerPrefs.GetInt("SceneNum") == 3)
        {
            if (Input.GetMouseButton(0))
            {
                transform.Translate(mainCam.transform.TransformDirection(Vector3.forward) * 7.0f * Time.deltaTime); //메인카메라가 바라보는 방향으로 플레이어 이동

                positionY = this.transform.position.y;

                if (positionY != 8.5f) //플레이어의 y위치를 고정
                    positionY = 8.5f;
                this.transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
            }
        }
    }
}
