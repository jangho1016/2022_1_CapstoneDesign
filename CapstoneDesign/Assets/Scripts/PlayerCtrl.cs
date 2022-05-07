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
    public Text timertext;
    public Text crackText;

    public GameObject mainCam;
    public GameObject managerPanel;

    private float timer;
    public float time_last;
    private float GaugeTimer = 0.0f;
    private float gazeTimer = 3.0f;
    private float positionY;

    public string curSceneName;

    private int cnt = 0;
    
    public bool[] isOpened = new bool[40];
    public bool[] crackChk = new bool[15];

    public AudioClip[] clips = new AudioClip[30];
    private AudioSource audioSource;
    Animation anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        curSceneName = SceneManager.GetActiveScene().name; //현재 씬 이름

        PlayerPrefs.SetInt("crack1", 0);
        PlayerPrefs.SetInt("crack2", 0);
        PlayerPrefs.SetInt("crack3", 0);
        PlayerPrefs.SetInt("crack4", 0);
        PlayerPrefs.SetInt("crack5", 0);
        PlayerPrefs.SetInt("crack6", 0);
        PlayerPrefs.SetInt("crack7", 0);
        PlayerPrefs.SetInt("crack8", 0);
        PlayerPrefs.SetInt("crack9", 0);
        PlayerPrefs.SetInt("crack10", 0);
        PlayerPrefs.SetInt("crack11", 0);
        PlayerPrefs.SetInt("crack12", 0);
        PlayerPrefs.SetInt("pass", 0);

        if ((curSceneName == "Room1") || (curSceneName == "Room2") || (curSceneName == "Room3") || (curSceneName == "Room4") || (curSceneName == "Room5")) //1-5번 방이면
        {
            PlayerPrefs.SetInt("SceneNum", 2); //씬넘버 2로 설정
        }
        else
            PlayerPrefs.SetInt("SceneNum", 0); //씬넘버 0으로
    }

    void Update()
    {
        rb.velocity = Vector3.zero; //플레이어 밀림현상 해결
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 1000; //forward값을 메인카메라가 바라보는 방향 * 1000으로 설정                                                                       
        cursorGauge.fillAmount = GaugeTimer; //커서게이지 이미지 채워서 게이지 로딩

        if (PlayerPrefs.GetInt("SceneNum") == 2) //방 1-5번이면
        {
            timer += Time.deltaTime; //타이머 시작
            timerGauge.fillAmount = timer / 300.0f;
            time_last = 301.0f - timer; //타이머 제한 시간 설정 (초 - 타이머)
            timertext.text = "남\n" + "은\n" + "시\n" + "간\n" + ((int)(time_last / 60) + "\n" + "분\n" + (int)(time_last % 60) + "\n" + "초"); //남은 시간 표시
            if (time_last <= 60.0f)
            {
                //timertext.text = "남은 시간 : " + (int)(time_last % 60) + "초"; //1분 미만일 때 타이머 표시
                timertext.text = "남\n" + "은\n" + "시\n" + "간\n" + ((int)(time_last / 60) + "\n" + "분\n" + (int)(time_last % 60) + "\n" + "초"); //남은 시간 표시
            }
            if (time_last <= 0.0f) //시간제한이 다 되면
                SceneManager.LoadScene("Fail1"); //방 선택 씬 로드

            else if(curSceneName == "Room1")
            {
                if(time_last >= 0.0f) //시간만 0초 이상이면
                {
                    crackText.text = "남은 하자: 0개";
                    PlayerPrefs.SetInt("pass", 1);
                }
            }

            else if(curSceneName == "Room2")
            {
                crackText.text = "남은 하자: " + (3 - cnt) + "개";

                if ((PlayerPrefs.GetInt("crack1") == 1) && (PlayerPrefs.GetInt("crack2") == 1) && (PlayerPrefs.GetInt("crack3") == 1) && (time_last >= 0.0f)) //이 부분 수정해야됨
                {
                    PlayerPrefs.SetInt("pass", 1);
                }
            }
            else if (curSceneName == "Room3")
            {
                crackText.text = "남은 하자: " + (3 - cnt) + "개";

                if ((PlayerPrefs.GetInt("crack4") == 1) && (PlayerPrefs.GetInt("crack5") == 1) && (PlayerPrefs.GetInt("crack6") == 1) && (time_last >= 0.0f)) //이 부분 수정해야됨
                {
                    PlayerPrefs.SetInt("pass", 1);
                }
            }
            else if(curSceneName == "Room4")
            {
                crackText.text = "남은 하자: " + (4 - cnt) + "개";

                if ((PlayerPrefs.GetInt("crack7") == 1) && (PlayerPrefs.GetInt("crack8") == 1) && (PlayerPrefs.GetInt("crack4") == 1) && (PlayerPrefs.GetInt("crack9") == 1) && (time_last >= 0.0f)) //이 부분 수정해야됨
                {
                    PlayerPrefs.SetInt("pass", 1);
                }
            }
            else if (curSceneName == "Room5")
            {
                crackText.text = "남은 하자: " + (5 - cnt) + "개";

                if ((PlayerPrefs.GetInt("crack9") == 1) && (PlayerPrefs.GetInt("crack10") == 1) && (PlayerPrefs.GetInt("crack4") == 1) && (PlayerPrefs.GetInt("crack11") == 1) && (PlayerPrefs.GetInt("crack12") == 1) && (time_last >= 0.0f)) //이 부분 수정해야됨
                {
                    PlayerPrefs.SetInt("pass", 1);
                }
            }
        }

        if (Physics.Raycast(this.transform.position, forward, out hit)) //오브젝트를 바라봤을 때
        {
            if(hit.transform.tag == "StartBT")
            {
                anim = GameObject.FindGameObjectWithTag("StartBT").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "WayBT")
            {
                anim = GameObject.FindGameObjectWithTag("WayBT").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "ExitBT")
            {
                anim = GameObject.FindGameObjectWithTag("ExitBT").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "MainBT")
            {
                anim = GameObject.FindGameObjectWithTag("MainBT").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "SelectBT1")
            {
                anim = GameObject.FindGameObjectWithTag("SelectBT1").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "SelectBT2")
            {
                anim = GameObject.FindGameObjectWithTag("SelectBT2").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "SelectBT3")
            {
                anim = GameObject.FindGameObjectWithTag("SelectBT3").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "SelectBT4")
            {
                anim = GameObject.FindGameObjectWithTag("SelectBT4").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "SelectBT5")
            {
                anim = GameObject.FindGameObjectWithTag("SelectBT5").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "Quiz")
            {
                anim = GameObject.FindGameObjectWithTag("Quiz").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "RoomSelect")
            {
                anim = GameObject.FindGameObjectWithTag("RoomSelect").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "QuizBT1")
            {
                anim = GameObject.FindGameObjectWithTag("QuizBT1").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "QuizBT2")
            {
                anim = GameObject.FindGameObjectWithTag("QuizBT2").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "QuizBT3")
            {
                anim = GameObject.FindGameObjectWithTag("QuizBT3").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "QuizBT4")
            {
                anim = GameObject.FindGameObjectWithTag("QuizBT4").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "YesBT")
            {
                anim = GameObject.FindGameObjectWithTag("YesBT").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "NoBT")
            {
                anim = GameObject.FindGameObjectWithTag("NoBT").GetComponent<Animation>();
                anim.Play();
            }
            else if (hit.transform.tag == "Button")
            {
                anim = GameObject.FindGameObjectWithTag("Button").GetComponent<Animation>();
                anim.Play();
            }

            GaugeTimer += 1.0f / gazeTimer * Time.deltaTime; //게이지 차는 시간은 3초
                
            if (GaugeTimer >= 1.0f) //게이지가 다 차면
            {
                if (PlayerPrefs.GetInt("SceneNum") == 0)
                {
                    if(PlayerPrefs.GetInt("SceneNum") == 0)
                    {
                        Debug.Log("test");
                    }
                    hit.transform.GetComponent<Button>().onClick.Invoke(); //버튼 이벤트 실행
                }
                    
                else if (PlayerPrefs.GetInt("SceneNum") == 2) //방 1-5번 씬일때
                {
                    if (hit.transform.tag == "Manager") //부동산 중개업자 오브젝트와 상호작용시
                        managerPanel.SetActive(true); //패널 활성화
                    else if ((hit.transform.tag == "YesBT") || (hit.transform.tag == "NoBT")) //버튼과 상호작용시
                        hit.transform.GetComponent<Button>().onClick.Invoke(); //버튼 이벤트 실행

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
                        audioSource.PlayOneShot(clips[12]);
                    }
                    else if ((hit.transform.tag == "Dresser1" == true) && (isOpened[9] == false))
                    {
                        isOpened[9] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "Dresser1" == true) && (isOpened[9] == true))
                    {
                        isOpened[9] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "Dresser2" == true) && (isOpened[10] == false))
                    {
                        isOpened[10] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "Dresser2" == true) && (isOpened[10] == true))
                    {
                        isOpened[10] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "Dresser3" == true) && (isOpened[11] == false))
                    {
                        isOpened[11] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "Dresser3" == true) && (isOpened[11] == true))
                    {
                        isOpened[11] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "Dresser4" == true) && (isOpened[12] == false))
                    {
                        isOpened[12] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "Dresser4" == true) && (isOpened[12] == true))
                    {
                        isOpened[12] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Dresser").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
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
                        audioSource.PlayOneShot(clips[14]);
                    }
                    else if ((hit.transform.tag == "Refrigerator1" == true) && (isOpened[18] == true) && (isOpened[20] == false))
                    {
                        isOpened[18] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[15]);
                    }
                    else if ((hit.transform.tag == "Refrigerator2" == true) && (isOpened[19] == false))
                    {
                        isOpened[19] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[14]);
                    }
                    else if ((hit.transform.tag == "Refrigerator2" == true) && (isOpened[19] == true) && (isOpened[21] == false && isOpened[22] == false && isOpened[23] == false))
                    {
                        isOpened[19] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[15]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD1" == true) && (isOpened[20] == false))
                    {
                        isOpened[20] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD1" == true) && (isOpened[20] == true))
                    {
                        isOpened[20] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD2" == true) && (isOpened[21] == false))
                    {
                        isOpened[21] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD2" == true) && (isOpened[21] == true))
                    {
                        isOpened[21] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD3" == true) && (isOpened[22] == false))
                    {
                        isOpened[22] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD3" == true) && (isOpened[22] == true))
                    {
                        isOpened[22] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD4" == true) && (isOpened[23] == false))
                    {
                        isOpened[23] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }
                    else if ((hit.transform.tag == "RefrigeratorD4" == true) && (isOpened[23] == true))
                    {
                        isOpened[23] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[13]);
                    }

                    else if ((hit.transform.tag == "Hood" == true) && (isOpened[24] == false))
                    {
                        isOpened[24] = true;
                        audioSource = GameObject.FindGameObjectWithTag("HoodFrame").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[16]);
                        audioSource.clip = clips[17];

                        if (curSceneName != "Room2")
                        {
                            audioSource.loop = true;
                            audioSource.Play();
                        }

                        else if (curSceneName == "Room2")
                        {
                            PlayerPrefs.SetInt("crack1", 1);
                            if ((crackChk[0] == false) && (PlayerPrefs.GetInt("crack1") == 1))
                            {
                                cnt++;
                                crackChk[0] = true;
                            }
                        }
                    }
                    else if ((hit.transform.tag == "Hood" == true) && (isOpened[24] == true))
                    {
                        isOpened[24] = false;
                        audioSource = GameObject.FindGameObjectWithTag("HoodFrame").GetComponent<AudioSource>();
                        audioSource.Stop();
                        audioSource.PlayOneShot(clips[16]);
                    }


                    else if ((hit.transform.tag == "RoomSwitch1" == true) && (isOpened[25] == false))
                    {
                        isOpened[25] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch1").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RoomSwitch1" == true) && (isOpened[25] == true))
                    {
                        isOpened[25] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch1").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RoomSwitch2" == true) && (isOpened[26] == false))
                    {
                        isOpened[26] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch1").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RoomSwitch2" == true) && (isOpened[26] == true))
                    {
                        isOpened[26] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch1").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "ToiletCover" == true) && (isOpened[27] == false))
                    {
                        isOpened[27] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Toilet").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[19]);
                    }
                    else if ((hit.transform.tag == "ToiletCover" == true) && (isOpened[27] == true))
                    {
                        isOpened[27] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Toilet").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[20]);
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
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "BathroomCdoor" == true) && (isOpened[30] == true))
                    {
                        isOpened[30] = false;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomC").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }
                    else if ((hit.transform.tag == "BathroomSwitch1" == true) && (isOpened[31] == false))
                    {
                        isOpened[31] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "BathroomSwitch1" == true) && (isOpened[31] == true))
                    {
                        isOpened[31] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "BathroomSwitch2" == true) && (isOpened[32] == false))
                    {
                        isOpened[32] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                        audioSource = GameObject.FindGameObjectWithTag("Ventilation").GetComponent<AudioSource>();
                        audioSource.clip = clips[27];

                        if (curSceneName != "Room2")
                        {
                            audioSource.loop = true;
                            audioSource.Play();
                        }
                        else if (curSceneName == "Room2")
                        {
                            PlayerPrefs.SetInt("crack3", 1);

                            if ((crackChk[2] == false) && (PlayerPrefs.GetInt("crack3") == 1))
                            {
                                cnt++;
                                crackChk[2] = true;
                            }
                        }
                    }
                    else if ((hit.transform.tag == "BathroomSwitch2" == true) && (isOpened[32] == true))
                    {
                        isOpened[32] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                        audioSource = GameObject.FindGameObjectWithTag("Ventilation").GetComponent<AudioSource>();
                        audioSource.Stop();
                    }
                    else if ((hit.transform.tag == "SinkFaucet" == true) && (isOpened[33] == false))
                    {
                        isOpened[33] = true;
                        audioSource = GameObject.FindGameObjectWithTag("RoomSink").GetComponent<AudioSource>();

                        audioSource.PlayOneShot(clips[21]);
                        if (curSceneName != "Room5")
                        {
                            audioSource.clip = clips[22];
                        }
                        else if (curSceneName == "Room5")
                        {
                            audioSource.clip = clips[28];
                        }
                        audioSource.loop = true;
                        audioSource.Play();

                        if (curSceneName == "Room5")
                        {
                            PlayerPrefs.SetInt("crack10", 1);

                            if ((crackChk[9] == false) && (PlayerPrefs.GetInt("crack10") == 1))
                            {
                                cnt++;
                                Debug.Log("Room5_1");
                                crackChk[9] = true;
                            }
                        }
                    }
                    else if ((hit.transform.tag == "SinkFaucet" == true) && (isOpened[33] == true))
                    {
                        isOpened[33] = false;
                        audioSource = GameObject.FindGameObjectWithTag("RoomSink").GetComponent<AudioSource>();
                        audioSource.Stop();
                        audioSource.PlayOneShot(clips[21]);
                    }
                    else if ((hit.transform.tag == "HeaterCtrl" == true) && (isOpened[34] == false))
                    {
                        isOpened[34] = true;
                        audioSource = GameObject.FindGameObjectWithTag("HeaterCtrl").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                        audioSource = GameObject.FindGameObjectWithTag("Heater").GetComponent<AudioSource>();
                        audioSource.clip = clips[17];
                        if (curSceneName != "Room4")
                        {
                            audioSource.loop = true;
                            audioSource.Play();
                        }

                        else if (curSceneName == "Room4")
                        {
                            PlayerPrefs.SetInt("crack8", 1);

                            if ((crackChk[7] == false) && (PlayerPrefs.GetInt("crack8") == 1))
                            {
                                cnt++;
                                crackChk[7] = true;
                            }
                        }
                    }
                    else if ((hit.transform.tag == "HeaterCtrl" == true) && (isOpened[34] == true))
                    {
                        isOpened[34] = false;
                        audioSource = GameObject.FindGameObjectWithTag("HeaterCtrl").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                        audioSource = GameObject.FindGameObjectWithTag("Heater").GetComponent<AudioSource>();
                        audioSource.Stop();
                    }
                    else if ((hit.transform.tag == "BathroomFaucet" == true) && (isOpened[35] == false))
                    {
                        isOpened[35] = true;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomSink").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[21]);
                        audioSource.clip = clips[22];
                        audioSource.loop = true;
                        audioSource.Play();

                        if (curSceneName == "Room3")
                        {
                            PlayerPrefs.SetInt("crack6", 1);

                            if ((crackChk[5] == false) && (PlayerPrefs.GetInt("crack6") == 1))
                            {
                                cnt++;
                                crackChk[5] = true;
                            }
                        }
                    }
                    else if ((hit.transform.tag == "BathroomFaucet" == true) && (isOpened[35] == true))
                    {
                        isOpened[35] = false;
                        audioSource = GameObject.FindGameObjectWithTag("BathroomSink").GetComponent<AudioSource>();
                        audioSource.Stop();
                        audioSource.PlayOneShot(clips[21]);
                    }
                    else if ((hit.transform.tag == "ShowerSwitch" == true) && (isOpened[36] == false))
                    {
                        isOpened[36] = true;
                        audioSource = GameObject.FindGameObjectWithTag("ShowerBooth").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[21]);
                        audioSource.clip = clips[23];
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                    else if ((hit.transform.tag == "ShowerSwitch" == true) && (isOpened[36] == true))
                    {
                        isOpened[36] = false;
                        audioSource = GameObject.FindGameObjectWithTag("ShowerBooth").GetComponent<AudioSource>();
                        audioSource.Stop();
                        audioSource.PlayOneShot(clips[21]);
                    }
                    else if ((hit.transform.tag == "RoomDoor2" == true) && (isOpened[37] == false))
                    {
                        isOpened[37] = true;
                        audioSource = GameObject.FindGameObjectWithTag("RoomDoor2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[0]);
                    }
                    else if ((hit.transform.tag == "RoomDoor2" == true) && (isOpened[37] == true))
                    {
                        isOpened[37] = false;
                        audioSource = GameObject.FindGameObjectWithTag("RoomDoor2").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[1]);
                    }
                    else if ((hit.transform.tag == "ToiletBT" == true) && isOpened[38] == false)
                    {
                        isOpened[38] = true;
                        StartCoroutine(ToiletWater());

                        audioSource = GameObject.FindGameObjectWithTag("Toilet").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[25]);
                        audioSource.PlayOneShot(clips[24]);
                    }
                    else if ((hit.transform.tag == "ShoeCase1" == true) && (isOpened[39] == false))
                    {
                        isOpened[39] = true;
                        audioSource = GameObject.FindGameObjectWithTag("ShoeCase").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "ShoeCase1" == true) && (isOpened[39] == true))
                    {
                        isOpened[39] = false;
                        audioSource = GameObject.FindGameObjectWithTag("ShoeCase").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }
                    else if ((hit.transform.tag == "ShoeCase2" == true) && (isOpened[40] == false))
                    {
                        isOpened[40] = true;
                        audioSource = GameObject.FindGameObjectWithTag("ShoeCase").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "ShoeCase2" == true) && (isOpened[40] == true))
                    {
                        isOpened[40] = false;
                        audioSource = GameObject.FindGameObjectWithTag("ShoeCase").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }
                    else if ((hit.transform.tag == "InductionDoor" == true) && (isOpened[41] == false))
                    {
                        isOpened[41] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Induction").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[7]);
                    }
                    else if ((hit.transform.tag == "InductionDoor" == true) && (isOpened[41] == true))
                    {
                        isOpened[41] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Induction").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[8]);
                    }

                    else if ((hit.transform.tag == "WasherBT" == true) && (isOpened[42] == false) && (isOpened[7] == false) && (isOpened[8] == false))
                    {
                        isOpened[42] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Washer").GetComponent<AudioSource>();
                        audioSource.clip = clips[11];
                        if (curSceneName != "Room2")
                        {
                            audioSource.loop = true;
                            audioSource.Play();
                        }

                        else if (curSceneName == "Room2")
                        {
                            PlayerPrefs.SetInt("crack2", 1);

                            if ((crackChk[1] == false) && (PlayerPrefs.GetInt("crack2") == 1))
                            {
                                cnt++;
                                crackChk[1] = true;
                            }
                        }
                    }
                    else if ((hit.transform.tag == "WasherBT" == true) && (isOpened[42] == true) && (isOpened[7] == false) && (isOpened[8] == false))
                    {
                        isOpened[42] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Washer").GetComponent<AudioSource>();
                        audioSource.Stop();
                    }

                    else if ((hit.transform.tag == "FireBT1" == true) && (isOpened[43] == false))
                    {
                        isOpened[43] = true;
                    }
                    else if ((hit.transform.tag == "FireBT1" == true) && (isOpened[43] == true))
                    {
                        isOpened[43] = false;
                    }

                    else if ((hit.transform.tag == "FireBT2" == true) && (isOpened[44] == false))
                    {
                        isOpened[44] = true;
                    }
                    else if ((hit.transform.tag == "FireBT2" == true) && (isOpened[44] == true))
                    {
                        isOpened[44] = false;
                    }
                    else if ((hit.transform.tag == "FireBT3" == true) && (isOpened[45] == false))
                    {
                        isOpened[45] = true;
                    }
                    else if ((hit.transform.tag == "FireBT3" == true) && (isOpened[45] == true))
                    {
                        isOpened[45] = false;
                    }
                    else if ((hit.transform.tag == "FireBT4" == true) && (isOpened[46] == false))
                    {
                        isOpened[46] = true;

                        if (curSceneName == "Room3")
                        {
                            PlayerPrefs.SetInt("crack5", 1);

                            if ((crackChk[4] == false) && (PlayerPrefs.GetInt("crack5") == 1))
                            {
                                cnt++;
                                crackChk[4] = true;
                            }
                        }
                    }
                    else if ((hit.transform.tag == "FireBT4" == true) && (isOpened[46] == true))
                    {
                        isOpened[46] = false;
                    }
                    else if ((hit.transform.tag == "ACCtrl" == true) && (isOpened[47] == false))
                    {
                        isOpened[47] = true;
                        audioSource = GameObject.FindGameObjectWithTag("ACCtrl").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                        audioSource = GameObject.FindGameObjectWithTag("AC").GetComponent<AudioSource>();
                        audioSource.clip = clips[26];
                        if (curSceneName != "Room4")
                        {
                            audioSource.loop = true;
                            audioSource.Play();
                        }

                        else if (curSceneName == "Room4")
                        {
                            PlayerPrefs.SetInt("crack7", 1);

                            if ((crackChk[6] == false) && (PlayerPrefs.GetInt("crack7") == 1))
                            {
                                cnt++;
                                crackChk[6] = true;
                            }
                        }
                    }
                    else if ((hit.transform.tag == "ACCtrl" == true) && (isOpened[47] == true))
                    {
                        isOpened[47] = false;
                        audioSource = GameObject.FindGameObjectWithTag("ACCtrl").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                        audioSource = GameObject.FindGameObjectWithTag("AC").GetComponent<AudioSource>();
                        audioSource.Stop();
                    }
                    else if ((hit.transform.tag == "RoomSwitch3" == true) && (isOpened[48] == false))
                    {
                        isOpened[48] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch3").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RoomSwitch3" == true) && (isOpened[48] == true))
                    {
                        isOpened[48] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch3").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RoomSwitch4" == true) && (isOpened[49] == false))
                    {
                        isOpened[49] = true;
                        audioSource = GameObject.FindGameObjectWithTag("Switch4").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if ((hit.transform.tag == "RoomSwitch4" == true) && (isOpened[49] == true))
                    {
                        isOpened[49] = false;
                        audioSource = GameObject.FindGameObjectWithTag("Switch4").GetComponent<AudioSource>();
                        audioSource.PlayOneShot(clips[18]);
                    }
                    else if (hit.transform.CompareTag("UnderCabinetL"))
                    {
                        if (isOpened[50])
                        {
                            isOpened[50] = false;
                            audioSource = GameObject.FindGameObjectWithTag("UnderCabinet").GetComponent<AudioSource>();
                            audioSource.PlayOneShot(clips[8]);
                        }
                        else
                        {
                            isOpened[50] = true;
                            audioSource = GameObject.FindGameObjectWithTag("UnderCabinet").GetComponent<AudioSource>();
                            audioSource.PlayOneShot(clips[7]);
                        }
                    }
                    else if (hit.transform.CompareTag("UnderCabinetR"))
                    {
                        if (isOpened[51])
                        {
                            isOpened[51] = false;
                            audioSource = GameObject.FindGameObjectWithTag("UnderCabinet").GetComponent<AudioSource>();
                            audioSource.PlayOneShot(clips[8]);
                        }
                        else
                        {
                            isOpened[51] = true;
                            audioSource = GameObject.FindGameObjectWithTag("UnderCabinet").GetComponent<AudioSource>();
                            audioSource.PlayOneShot(clips[7]);
                        }
                    }
                    else if (hit.transform.tag == "Crack" == true)
                    {
                        if ((curSceneName == "Room3") || (curSceneName == "Room4") || (curSceneName == "Room5"))
                        {
                            PlayerPrefs.SetInt("crack4", 1);

                            if ((crackChk[3] == false) && (PlayerPrefs.GetInt("crack4") == 1))
                            {
                                cnt++;
                                crackChk[3] = true;
                                Debug.Log("Room5_2");
                            }
                        }
                    }
                    else if (hit.transform.tag == "Crack2" == true)
                    {
                        if ((curSceneName == "Room4") || (curSceneName == "Room5"))
                        {
                            PlayerPrefs.SetInt("crack9", 1);

                            if ((crackChk[8] == false) && (PlayerPrefs.GetInt("crack9") == 1))
                            {
                                cnt++;
                                crackChk[8] = true;
                                Debug.Log("Room5_3");
                            }
                        }
                    }
                    else if (hit.transform.tag == "Mold" == true)
                    {
                        PlayerPrefs.SetInt("crack11", 1);

                        if ((crackChk[10] == false) && (PlayerPrefs.GetInt("crack11") == 1))
                        {
                            cnt++;
                            crackChk[10] = true;
                            Debug.Log("Room5_4");
                        }
                    }
                    else if (hit.transform.tag == "Cockroach" == true)
                    {
                        PlayerPrefs.SetInt("crack12", 1);

                        if ((crackChk[11] == false) && (PlayerPrefs.GetInt("crack12") == 1))
                        {
                            cnt++;
                            crackChk[11] = true;
                            Debug.Log("Room5_5");
                        }
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
    IEnumerator ToiletWater()
    {
        yield return new WaitForSeconds(0.1f);
        isOpened[38] = false;
    }
}