using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody rb;
    public Image cursorGauge;
    public Image timerGauge;
    public GameObject mainCam;
    private float GaugeTimer = 0.0f;
    private float gazeTimer = 2.0f;
    private float positionY;
    private string curSceneName;
    private int cnt = 0;
    public GameObject managerPanel;
    public Text timertext;
    private float timer;
    public float time_last;
    public GameObject RoomLight1;
    public bool[] isOpened = new bool[40];
    public AudioClip[] clips = new AudioClip[50];
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        curSceneName = SceneManager.GetActiveScene().name; //씬 이름 가져옴
        if ((curSceneName == "Room1") || (curSceneName == "Room2") || (curSceneName == "Room3") || (curSceneName == "Room4") || (curSceneName == "Room5")) //1-5번 방이면
        {
            PlayerPrefs.SetInt("SceneNum", 2); //씬넘버 2로 설정
            PlayerPrefs.SetInt("pass", 0); //패스하기 위한 값 초기화
        }
        else if (curSceneName == "Loading")
            StartCoroutine(LoadScene());
        else
            PlayerPrefs.SetInt("SceneNum", 0); //씬넘버 0으로
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
            timerGauge.fillAmount = timer / 900.0f;
            time_last = 901.0f - timer; //타이머 제한 시간 설정 (초 - 타이머)
            timertext.text = "남\n" + "은\n" + "시\n" + "간\n" + ((int)(time_last / 60) + "\n" + "분\n" + (int)(time_last % 60) + "\n" + "초"); //남은 시간 표시
            if (time_last <= 60.0f)
            {
                //timertext.text = "남은 시간 : " + (int)(time_last % 60) + "초"; //1분 미만일 때 타이머 표시
                timertext.text = "남\n" + "은\n" + "시\n" + "간\n" + ((int)(time_last / 60) + "\n" + "분\n" + (int)(time_last % 60) + "\n" + "초"); //남은 시간 표시
            }
            if (time_last <= 0.0f) //시간제한이 다 되면
                SceneManager.LoadScene("Select"); //방 선택 씬 로드
            else if ((cnt == 1) && (time_last >= 0.0f)) //방에서 하자 부분을 발견하고 시간제한에 걸리지 않았을 때
            {
                Debug.Log("success");
                PlayerPrefs.SetInt("pass", 1); //통과하도록 설정
            }
            else if (cnt >= 2)
                PlayerPrefs.SetInt("pass", 0); //통과하도록 설정
        }
        if (Physics.Raycast(this.transform.position, forward, out hit)) //바라봤을 때
        {
            if (PlayerPrefs.GetInt("SceneNum") == 2)
            {
                if (hit.transform.tag == "Untagged")
                {
                    GaugeTimer = 0.0f; //게이지를 채우지 않음
                }
            }

            GaugeTimer += 1.0f / gazeTimer * Time.deltaTime; //게이지 차는 시간은 3초
                
            if (GaugeTimer >= 1.0f) //게이지가 다 차면
            {
                if (PlayerPrefs.GetInt("SceneNum") == 0) //방 1-5번이 아닐때
                    hit.transform.GetComponent<Button>().onClick.Invoke(); //버튼 이벤트 실행
                else if (PlayerPrefs.GetInt("SceneNum") == 2) //방 1-5번 씬일때
                {  
                    if (hit.transform.tag == "Crack") //방에서 하자 부분을 발견했을때
                        cnt++;
                    else if (hit.transform.tag == "Manager") //부동산 중개업자와 상호작용시
                        managerPanel.SetActive(true); //패널 활성
                    else if (hit.transform.tag == "Button") //버튼과 상호작용시
                        hit.transform.GetComponent<Button>().onClick.Invoke(); //버튼 이벤트 실행

                    else if ((hit.transform.tag == "RoomDoor" == true) && (isOpened[0] == false))
                    {
                        isOpened[0] = true;
                        audioSource = GameObject.FindGameObjectWithTag("RoomDoor").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[0]);
                    }
                    else if ((hit.transform.tag == "RoomDoor" == true) && (isOpened[0] == true))
                    {
                        isOpened[0] = false;
                        audioSource = GameObject.FindGameObjectWithTag("RoomDoor").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[1]);
                    }


                    else if ((hit.transform.tag == "BathroomDoor" == true) && (isOpened[1] == false)) 
                    {
                        isOpened[1] = true;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomDoor").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[0]);
                    }
                    else if ((hit.transform.tag == "BathroomDoor" == true) && (isOpened[1] == true))
                    {
                        isOpened[1] = false;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomDoor").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[1]);
                    }


                    else if ((hit.transform.tag == "Window" == true) && (isOpened[2] == false))
                    {
                        isOpened[2] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Window").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[2]);
                    }
                    else if ((hit.transform.tag == "Window" == true) && (isOpened[2] == true))
                    {
                        isOpened[2] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Window").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[3]);
                    }  


                    else if ((hit.transform.tag == "MicrowaveOpener" == true) && (isOpened[3] == false) && (isOpened[4] == false))
                    {
                        isOpened[3] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Microwave").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[4]);
                    }
                    else if ((hit.transform.tag == "MicrowaveDoor" == true) && (isOpened[3] == true) && (isOpened[4] == false))
                    {
                        isOpened[3] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Microwave").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[5]);
                    } 
                    else if ((hit.transform.tag == "MicrowaveBT" == true) && (isOpened[4] == false) && (isOpened[3] == false))
                    {
                        isOpened[4] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Microwave").GetComponent<AudioSource>();
                        audioSource.clip = clips[6];
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                    else if ((hit.transform.tag == "MicrowaveBT" == true) && (isOpened[4] == true) && (isOpened[3] == false))
                    {
                        isOpened[4] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Microwave").GetComponent<AudioSource>();
                        audioSource.Stop();
                    }


                    else if ((hit.transform.tag == "SinkL" == true) && (isOpened[5] == false))
                    {
                        isOpened[5] = true;
                        audioSource = GameObject.FindGameObjectWithTag("RoomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "SinkL" == true) && (isOpened[5] == true))
                    {
                        isOpened[5] = false;
                        audioSource = GameObject.FindGameObjectWithTag("RoomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }

                    //클립 7/8번이 문 90도로 여는 소리

                    else if ((hit.transform.tag == "SinkR" == true) && (isOpened[6] == false))
                    {
                        isOpened[6] = true;
                        audioSource = GameObject.FindGameObjectWithTag("RoomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "SinkR" == true) && (isOpened[6] == true))
                    {
                        isOpened[6] = false;
                        audioSource = GameObject.FindGameObjectWithTag("RoomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }

                    else if ((hit.transform.tag == "WasherDoor" == true) && (isOpened[7] == false) && (isOpened[42] == false))
                    {
                        isOpened[7] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Washer").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[9]);
                    } 
                    else if ((hit.transform.tag == "WasherDoor" == true) && (isOpened[7] == true) && (isOpened[42] == false))
                    {
                        isOpened[7] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Washer").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[10]);
                    }
                        
                    else if ((hit.transform.tag == "WasherDrawer" == true) && (isOpened[8] == false) && (isOpened[42] == false))
                    {
                        isOpened[8] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Washer").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[12]);
                    }
                    else if ((hit.transform.tag == "WasherDrawer" == true) && (isOpened[8] == true) && (isOpened[42] == false))
                    {
                        isOpened[8] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Washer").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "Dresser1" == true) && (isOpened[9] == false))
                    {
                        isOpened[9] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[14]);
                    }
                    else if ((hit.transform.tag == "Dresser1" == true) && (isOpened[9] == true)) 
                    {
                        isOpened[9] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[15]);
                    }
                    else if ((hit.transform.tag == "Dresser2" == true) && (isOpened[10] == false))
                    {
                        isOpened[10] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[14]);
                    }
                    else if ((hit.transform.tag == "Dresser2" == true) && (isOpened[10] == true))
                    {
                        isOpened[10] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[15]);
                    }
                    else if ((hit.transform.tag == "Dresser3" == true) && (isOpened[11] == false))
                    {
                        isOpened[11] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[14]);
                    }
                    else if ((hit.transform.tag == "Dresser3" == true) && (isOpened[11] == true))
                    {
                        isOpened[11] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[15]);
                    }
                    else if ((hit.transform.tag == "Dresser4" == true) && (isOpened[12] == false))
                    {
                        isOpened[12] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[14]);
                    }
                    else if ((hit.transform.tag == "Dresser4" == true) && (isOpened[12] == true))
                    {
                        isOpened[12] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[15]);
                    }


                    else if ((hit.transform.tag == "CabinetL" == true) && (isOpened[13] == false))
                    {
                        isOpened[13] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Cabinet").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "CabinetL" == true) && (isOpened[13] == true))
                    {
                        isOpened[13] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Cabinet").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }

                    else if ((hit.transform.tag == "CabinetR" == true) && (isOpened[14] == false))
                    {
                        isOpened[14] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Cabinet").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "CabinetR" == true) && (isOpened[14] == true))
                    {
                        isOpened[14] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Cabinet").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }

                    else if ((hit.transform.tag == "WardrobeL" == true) && (isOpened[15] == false))
                    {
                        isOpened[15] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Wardrobe").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                       
                    else if ((hit.transform.tag == "WardrobeL" == true) && (isOpened[15] == true))
                    {
                        isOpened[15] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Wardrobe").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }
                    else if ((hit.transform.tag == "WardrobeM" == true) && (isOpened[16] == false))
                    {
                        isOpened[16] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Wardrobe").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "WardrobeM" == true) && (isOpened[16] == true))
                    {
                        isOpened[16] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Wardrobe").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }

                    else if ((hit.transform.tag == "WardrobeR" == true) && (isOpened[17] == false))
                    {
                        isOpened[17] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Wardrobe").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "WardrobeR" == true) && (isOpened[17] == true))
                    {
                        isOpened[17] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Wardrobe").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }


                    else if ((hit.transform.tag == "Refrigerator1" == true) && (isOpened[18] == false))
                    {
                        isOpened[18] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[16]);
                    }
                    else if ((hit.transform.tag == "Refrigerator1" == true) && (isOpened[18] == true) && (isOpened[20] == false))
                    {
                        isOpened[18] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[17]);
                    }
                    else if ((hit.transform.tag == "Refrigerator2" == true) && (isOpened[19] == false))
                    {
                        isOpened[19] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[16]);
                    }
                    else if ((hit.transform.tag == "Refrigerator2" == true) && (isOpened[19] == true) && (isOpened[21] == false && isOpened[22] == false && isOpened[23] == false))
                    {
                        isOpened[19] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[17]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD1" == true) && (isOpened[20] == false))
                    {
                        isOpened[20] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD1" == true) && (isOpened[20] == true))
                    {
                        isOpened[20] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[19]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD2" == true) && (isOpened[21] == false))
                    {
                        isOpened[21] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD2" == true) && (isOpened[21] == true))
                    {
                        isOpened[21] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[19]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD3" == true) && (isOpened[22] == false))
                    {
                        isOpened[22] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD3" == true) && (isOpened[22] == true))
                    {
                        isOpened[22] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[19]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD4" == true) && (isOpened[23] == false))
                    {
                        isOpened[23] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD4" == true) && (isOpened[23] == true))
                    {
                        isOpened[23] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[19]);
                    }

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    else if ((hit.transform.tag == "Hood" == true) && (isOpened[24] == false))
                    {
                        isOpened[24] = true;
                        audioSource = GameObject.FindGameObjectWithTag("HoodFrame").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[20]);
                        audioSource.clip = clips[22];
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                    else if ((hit.transform.tag == "Hood" == true) && (isOpened[24] == true))
                    {
                        isOpened[24] = false;
                        audioSource = GameObject.FindGameObjectWithTag("HoodFrame").GetComponent<AudioSource>();
                        audioSource.Stop();
                        audioSource.PlayOneShot(clips[21]);
                    }


                    else if ((hit.transform.tag == "RoomSwitch1" == true) && (isOpened[25] == false))
                    {
                        isOpened[25] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch1").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[23]);
                    }
                    else if ((hit.transform.tag == "RoomSwitch1" == true) && (isOpened[25] == true))
                    {
                        isOpened[25] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch1").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[24]);
                    }
                    else if ((hit.transform.tag == "RoomSwitch2" == true) && (isOpened[26] == false))
                    {
                        isOpened[26] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch1").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[23]);
                    }
                    else if ((hit.transform.tag == "RoomSwitch2" == true) && (isOpened[26] == true))
                    {
                        isOpened[26] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch1").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[24]);
                    }
                    else if ((hit.transform.tag == "ToiletCover" == true) && (isOpened[27] == false))
                    {
                        isOpened[27] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Toilet").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[25]);
                    }
                    else if ((hit.transform.tag == "ToiletCover" == true) && (isOpened[27] == true))
                    {
                        isOpened[27] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Toilet").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[26]);
                    }
                    
                    else if ((hit.transform.tag == "BathroomD1" == true) && (isOpened[28] == false)) 
                    {
                        isOpened[28] = true;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "BathroomD1" == true) && (isOpened[28] == true)) 
                    {
                        isOpened[28] = false;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }
                    else if ((hit.transform.tag == "BathroomD2" == true) && (isOpened[29] == false)) 
                    {
                        isOpened[29] = true;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "BathroomD2" == true) && (isOpened[29] == true)) 
                    {
                        isOpened[29] = false;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }
                    else if ((hit.transform.tag == "BathroomCdoor" == true) && (isOpened[30] == false))
                    {
                        isOpened[30] = true;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomC").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[27]);
                    }
                    else if ((hit.transform.tag == "BathroomCdoor" == true) && (isOpened[30] == true))
                    {
                        isOpened[30] = false;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomC").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[28]);
                    }
                    else if ((hit.transform.tag == "BathroomSwitch1" == true) && (isOpened[31] == false))
                    {
                        isOpened[31] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[23]);
                    }
                    else if ((hit.transform.tag == "BathroomSwitch1" == true) && (isOpened[31] == true))
                    {
                        isOpened[31] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[24]);
                    }
                    else if ((hit.transform.tag == "BathroomSwitch2" == true) && (isOpened[32] == false))
                    {
                        isOpened[32] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[23]);
                    }
                    else if ((hit.transform.tag == "BathroomSwitch2" == true) && (isOpened[32] == true))
                    {
                        isOpened[32] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[24]);
                    }
                    else if ((hit.transform.tag == "SinkFaucet" == true) && (isOpened[33] == false))
                    {
                        isOpened[33] = true;
                        audioSource = GameObject.FindGameObjectWithTag("RoomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[29]);
                        audioSource.clip = clips[31];
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                    else if ((hit.transform.tag == "SinkFaucet" == true) && (isOpened[33] == true))
                    {
                        isOpened[33] = false;
                        audioSource = GameObject.FindGameObjectWithTag("RoomSink").GetComponent<AudioSource>();
                        audioSource.Stop();
                        audioSource.PlayOneShot(clips[30]);
                    }
                    else if ((hit.transform.tag == "HeaterCtrl" == true) && (isOpened[34] == false))
                    {
                        isOpened[34] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Heater").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[32]);
                        audioSource.clip = clips[34];
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                    else if ((hit.transform.tag == "HeaterCtrl" == true) && (isOpened[34] == true))
                    {
                        isOpened[34] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Heater").GetComponent<AudioSource>();
                        
                        audioSource.Stop();
                        audioSource.PlayOneShot(clips[33]);
                    }
                    else if ((hit.transform.tag == "BathroomFaucet" == true) && (isOpened[35] == false))
                    {
                        isOpened[35] = true;
                    }
                    else if ((hit.transform.tag == "BathroomFaucet" == true) && (isOpened[35] == true))
                    {
                        isOpened[35] = false;
                    }
                    else if ((hit.transform.tag == "ShowerSwitch" == true) && (isOpened[36] == false))
                    {
                        isOpened[36] = true;
                    }
                    else if ((hit.transform.tag == "ShowerSwitch" == true) && (isOpened[36] == true))
                    {
                        isOpened[36] = false;
                    }
                    else if ((hit.transform.tag == "RoomDoor2" == true) && (isOpened[37] == false))
                    {
                        isOpened[37] = true;
                    }
                    else if ((hit.transform.tag == "RoomDoor2" == true) && (isOpened[37] == true))
                    {
                        isOpened[37] = false;
                    }
                    else if ((hit.transform.tag == "ToiletBT" == true) && isOpened[38] == false)
                    {
                        isOpened[38] = true;
                        StartCoroutine(ToiletWater());
                    }
                    else if ((hit.transform.tag == "ShoseCase1" == true) && (isOpened[39] == false))
                    {
                        isOpened[39] = true;
                    }
                    else if ((hit.transform.tag == "ShoseCase1" == true) && (isOpened[39] == true))
                    {
                        isOpened[39] = false;
                    }
                    else if ((hit.transform.tag == "ShoseCase2" == true) && (isOpened[40] == false))
                    {
                        isOpened[40] = true;
                    }
                    else if ((hit.transform.tag == "ShoseCase2" == true) && (isOpened[40] == true))
                    {
                        isOpened[40] = false;
                    }
                    else if ((hit.transform.tag == "Induction" == true) && (isOpened[41] == false))
                    {
                        isOpened[41] = true;
                    }
                    else if ((hit.transform.tag == "Induction" == true) && (isOpened[41] == true))
                    {
                        isOpened[41] = false;
                    }

                    else if ((hit.transform.tag == "WasherBT" == true) && (isOpened[42] == false) && (isOpened[7] == false) && (isOpened[8] == false))
                    {
                        isOpened[42] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Washer").GetComponent<AudioSource>();
                        audioSource.clip = clips[11];
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                    else if ((hit.transform.tag == "WasherBT" == true) && (isOpened[42] == true) && (isOpened[7] == false) && (isOpened[8] == false))
                    {
                        isOpened[42] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Washer").GetComponent<AudioSource>();
                        audioSource.Stop();
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
                    positionY = 10.0f; //플레이어의 y위치를 고정 (아래나 위로 내려가지 않게)
                this.transform.position = new Vector3(transform.position.x, positionY, transform.position.z); //플레이어의 y축 고정
            }
        }
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Select");
    }

    IEnumerator ToiletWater()
    {
        yield return new WaitForSeconds(0.1f);
        isOpened[38] = false;
    }
}
