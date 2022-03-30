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
    private int cnt = 0;
    public GameObject pPanel;
    public Text timertext;
    private float timer;
    public float time_last;
    bool windowisOpen = false;
    bool refrigeratorisOpen = false;
    bool toiletisOpen = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        curSceneName = SceneManager.GetActiveScene().name; //씬 이름 가져옴

        if ((curSceneName == "Room1") || (curSceneName == "Room2") || (curSceneName == "Room3") || (curSceneName == "Room4") || (curSceneName == "Room5")) //1-5번 방이면
        {
            PlayerPrefs.SetInt("SceneNum", 2); //씬넘버 2로 설정
            PlayerPrefs.SetInt("pass", 0); //패스하기 위한 값 초기화

            PlayerPrefs.SetInt("Window", 0);
            PlayerPrefs.SetInt("Refrigerator", 0);
            PlayerPrefs.SetInt("Toilet", 0);

        }
        else if (curSceneName == "Loading")
        {
            StartCoroutine(LoadScene());
        }
        else
        {
            PlayerPrefs.SetInt("SceneNum", 0); //씬넘버 0으로
        }
    }

    void Update()
    {
        rb.velocity = Vector3.zero; //밀림현상 때문에
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 1000; //forward값을 메인카메라가 바라보는 방향 * 1000으로 설정
        cursorGauge.fillAmount = GaugeTimer; //커서게이지 이미지 채워서 게이지 로딩

        Debug.DrawRay(transform.position, forward, Color.red); //레이 확인하기 위함

        if (PlayerPrefs.GetInt("SceneNum") == 2) //방 1-5번이면
        {
            timer += Time.deltaTime; //타이머 시작

            time_last = 15.0f - timer; //타이머 제한 시간 설정 (초 - 타이머)

            timertext.text = "남은 시간 : " + ((int)(time_last / 60) + "분" + (int)(time_last % 60) + "초"); //남은 시간 표시

            if (time_last <= 60.0f)
            {
                timertext.text = "남은 시간 : " + (int)(time_last % 60) + "초"; //1분 미만일 때 타이머 표시
            }

            if (time_last <= 0.0f) //시간제한이 다 되면
            {
                SceneManager.LoadScene("Select"); //방 선택 씬 로드
            }
            
            else if ((cnt == 1) && (time_last >= 0.0f)) //방에서 하자 부분을 발견하고 시간제한에 걸리지 않았을 때
            {
                PlayerPrefs.SetInt("pass", 1); //통과하도록 설정
            }
            else if(cnt >= 2)
            {
                PlayerPrefs.SetInt("pass", 0); //통과하도록 설정
            }
        }

        if (Physics.Raycast(this.transform.position, forward, out hit)) //바라봤을 때
        {
            GaugeTimer += 1.0f / gazeTimer * Time.deltaTime; //게이지 차는 시간은 3초
            //Debug.Log(hit.transform.name);

            if (GaugeTimer >= 1.0f) //게이지가 다 차면
            {
                if (PlayerPrefs.GetInt("SceneNum") == 0) //방 1-5번이 아닐때
                {
                    hit.transform.GetComponent<Button>().onClick.Invoke(); //버튼 이벤트 실행
                }
                
                else if (PlayerPrefs.GetInt("SceneNum") == 2) //방 1-5번 씬일때
                {   
                    if (hit.transform.tag == "Untagged") //태그 없는 물체 바라보면
                    {
                        GaugeTimer = 0.0f; //게이지를 채우지 않음
                    }
                    else if(hit.transform.tag == "Crack") //방에서 하자 부분을 발견했을때
                    {
                        cnt++; //카운트 증가
                    }
                    else if(hit.transform.tag == "Manager") //부동산 중개업자와 상호작용시
                    {
                        pPanel.SetActive(true); //패널 활성화
                    }
                    else if(hit.transform.tag == "Button") //버튼과 상호작용시
                    {
                        hit.transform.GetComponent<Button>().onClick.Invoke(); //버튼 이벤트 실행
                    }

                    else if ((hit.transform.tag == "Window" == true) && (windowisOpen == false)) //태그 없는 물체 바라보면
                    {
                        PlayerPrefs.SetInt("Window", 1);
                        windowisOpen = true;
                    }

                    else if ((hit.transform.tag == "Window" == true) && (windowisOpen == true)) //태그 없는 물체 바라보면
                    {
                        PlayerPrefs.SetInt("Window", 0);
                        windowisOpen = false;
                    }

                    else if ((hit.transform.tag == "Refrigerator" == true) && (refrigeratorisOpen == false)) //태그 없는 물체 바라보면
                    {
                        PlayerPrefs.SetInt("Refrigerator", 1);
                        refrigeratorisOpen = true;
                    }

                    else if ((hit.transform.tag == "Refrigerator" == true) && (refrigeratorisOpen == true)) //태그 없는 물체 바라보면
                    {
                        PlayerPrefs.SetInt("Refrigerator", 0);
                        refrigeratorisOpen = false;
                    }

                    else if ((hit.transform.tag == "Toilet Cover" == true) && (toiletisOpen == false)) //태그 없는 물체 바라보면
                    {
                        PlayerPrefs.SetInt("Toilet", 1);
                        toiletisOpen = true;
                    }

                    else if ((hit.transform.tag == "Toilet Cover" == true) && (toiletisOpen == true)) //태그 없는 물체 바라보면
                    {
                        PlayerPrefs.SetInt("Toilet", 0);
                        toiletisOpen = false;
                    }
                }
                GaugeTimer = 0.0f; //게이지 0으로
            }
        }
        else
            GaugeTimer = 0.0f;

        if (PlayerPrefs.GetInt("SceneNum") == 2) //방 Scene이면
        {
            if (Input.GetMouseButton(0)) //화면 누르고 있을 시
            {
                transform.Translate(mainCam.transform.TransformDirection(Vector3.forward) * 7.0f * Time.deltaTime); //메인카메라가 바라보는 방향으로 플레이어 이동

                positionY = this.transform.position.y; //플레이어의 y좌표 받아옴

                if (positionY != 10.0f) //초기 설정된 플레이어의 위치가 아니면
                {
                    positionY = 10.0f; //플레이어의 y위치를 고정 (아래나 위로 내려가지 않게)
                }
                this.transform.position = new Vector3(transform.position.x, positionY, transform.position.z); //플레이어의 y축 고정
            }
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Select");
    }
}
