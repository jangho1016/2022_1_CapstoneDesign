using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody rb;
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


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPrefs.SetInt("SceneNum", 0);

        curSceneName = SceneManager.GetActiveScene().name;

        if ((curSceneName == "Room1") || (curSceneName == "Room2") || (curSceneName == "Room3") || (curSceneName == "Room4") || (curSceneName == "Room5"))
        {
            PlayerPrefs.SetInt("SceneNum", 2);
            PlayerPrefs.SetInt("pass", 0);
        }
        else
        {
            PlayerPrefs.SetInt("SceneNum", 0);
        }
    }

    void Update()
    {
        rb.velocity = Vector3.zero; //밀림현상 때문에
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 1000;
        cursorGauge.fillAmount = GaugeTimer;

        Debug.DrawRay(transform.position, forward, Color.red);

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            GaugeTimer += 1.0f / gazeTimer * Time.deltaTime;

            if (GaugeTimer >= 1.0f)
            {
                if (PlayerPrefs.GetInt("SceneNum") == 0)
                {
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                }
                
                else if (PlayerPrefs.GetInt("SceneNum") == 2)
                {
                    if (hit.transform.tag == "Untagged")
                    {
                        GaugeTimer = 0.0f;
                    }
                    else if(hit.transform.tag == "Crack")
                    {
                        cnt++;
                    }
                }
                GaugeTimer = 0.0f;
            }
        }
        else
            GaugeTimer = 0.0f;

        if (PlayerPrefs.GetInt("SceneNum") == 2) //방 Scene이면
        {
            if (Input.GetMouseButton(0)) //화면 누르고 있을 시
            {
                transform.Translate(mainCam.transform.TransformDirection(Vector3.forward) * 7.0f * Time.deltaTime); //메인카메라가 바라보는 방향으로 플레이어 이동

                positionY = this.transform.position.y;

                if (positionY != 10.0f)
                {
                    positionY = 10.0f; //플레이어의 y위치를 고정 (아래나 위로 내려가지 않게)
                }
                this.transform.position = new Vector3(transform.position.x, positionY, transform.position.z); //플레이어의 y축 고정
            }
        }
    }
}
