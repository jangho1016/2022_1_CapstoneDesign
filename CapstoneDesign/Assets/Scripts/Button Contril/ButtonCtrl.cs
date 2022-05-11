using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    GameObject ManagerPanel;
    int num;

    private void Start()
    {
        num = PlayerPrefs.GetInt("rand_num"); //랜덤 값 가져옴
    }

    public void StartBT() //시작 버튼
    {
        SceneManager.LoadScene("Loading Scene"); //Select room 씬 로딩
    }

    public void MainBT() //메인화면으로 가기 버튼
    {
        SceneManager.LoadScene("Start Scene"); //시작 씬 로딩
    }

    public void Information()
    {
        SceneManager.LoadScene("Information Scene"); //진행 방식 씬 로딩
    }

    public void ExitBT() //종료 버튼
    {
        Application.Quit(); //종료
    }

    public void Yes() //방 1-5번 씬에서 성공 실패 여부
    {
        if(PlayerPrefs.GetInt("pass") == 1) //성공시
        {
            PlayerPrefs.SetInt("rand_num", 0); //랜덤 숫자 초기화
            SceneManager.LoadScene("Success Scene 1"); //성공 씬1 로드
        }
        else
        {
            SceneManager.LoadScene("Fail Scene 1"); //실패 씬1 로드
        }
    }

    public void No()
    {
        ManagerPanel = GameObject.FindGameObjectWithTag("ManagerPanel"); //부동산 중개업자 위의 이미지 찾기
        ManagerPanel.gameObject.SetActive(false); //패널 비활성화
    }

    public void SelectBT1() //값 랜덤 가져와 씬 로드
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room 1 Floor Plan");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room 2 Floor Plan");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room 3 Floor Plan");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room 4 Floor Plan");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room 5 Floor Plan");
        }
    }

    public void SelectBT2()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room 5 Floor Plan");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room 1 Floor Plan");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room 2 Floor Plan");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room 3 Floor Plan");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room 4 Floor Plan");
        }
    }

    public void SelectBT3()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room 4 Floor Plan");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room 5 Floor Plan");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room 1 Floor Plan");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room 2 Floor Plan");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room 3 Floor Plan");
        }
    }

    public void SelectBT4()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room 3 Floor Plan");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room 4 Floor Plan");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room 5 Floor Plan");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room 1 Floor Plan");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room 2 Floor Plan");
        }
    }
    public void SelectBT5()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room 2 Floor Plan");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room 3 Floor Plan");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room 4 Floor Plan");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room 5 Floor Plan");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room 1 Floor Plan");
        }
    }
    public void RoomSelect() //방 선택화면 버튼
    {
        SceneManager.LoadScene("Map Select Scene"); //방 선택화면 씬 로드
    }
    public void Quiz() //계약사항퀴즈 버튼
    {
        SceneManager.LoadScene("Quiz Scene"); //계약사항퀴즈 씬 로드
    }

    public void RealRoom() //실제방 버튼
    {
        SceneManager.LoadScene("Real Room 1");
    }

    public void RealRoom1()
    {
        SceneManager.LoadScene("Real Room 1 Bathroom");
    }
    public void RealRoom2()
    {
        SceneManager.LoadScene("Real Room 2 Bathroom");
    }
    public void RealRoom3()
    {
        SceneManager.LoadScene("Real Room 3 Bathroom");
    }
    public void RealRoom4()
    {
        SceneManager.LoadScene("Real Room 4 Bathroom");
    }
    public void RealRoomBathroom1() //실제방 화장실 버튼
    {
        SceneManager.LoadScene("Real Room 2");
    }
    public void RealRoomBathroom2()
    {
        SceneManager.LoadScene("Real Room 3");
    }
    public void RealRoomBathroom3()
    {
        SceneManager.LoadScene("Real Room 4");
    }
    public void RealRoomBathroom4() //재시작 버튼
    {
        SceneManager.LoadScene("Restart Scene"); //재시작 씬 로드
    }
}
