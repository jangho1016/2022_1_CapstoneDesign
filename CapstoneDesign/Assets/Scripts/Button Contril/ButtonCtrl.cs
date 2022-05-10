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
        SceneManager.LoadScene("Loading"); //Select room 씬 로딩
    }

    public void MainBT() //메인화면으로 가기 버튼
    {
        SceneManager.LoadScene("Start Scene"); //시작 씬 로딩
    }

    public void Information()
    {
        SceneManager.LoadScene("Information"); //진행 방식 씬 로딩
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
            SceneManager.LoadScene("Success1"); //성공 씬1 로드
        }
        else
        {
            SceneManager.LoadScene("Fail1"); //실패 씬1 로드
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
            SceneManager.LoadScene("Room1 Drawing");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room2 Drawing");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room3 Drawing");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room4 Drawing");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room5 Drawing");
        }
    }

    public void SelectBT2()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room5 Drawing");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room1 Drawing");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room2 Drawing");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room3 Drawing");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room4 Drawing");
        }
    }

    public void SelectBT3()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room4 Drawing");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room5 Drawing");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room1 Drawing");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room2 Drawing");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room3 Drawing");
        }
    }

    public void SelectBT4()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room3 Drawing");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room4 Drawing");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room5 Drawing");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room1 Drawing");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room2 Drawing");
        }
    }
    public void SelectBT5()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room2 Drawing");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room3 Drawing");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room4 Drawing");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room5 Drawing");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room1 Drawing");
        }
    }
    public void RoomSelect() //방 선택화면 버튼
    {
        SceneManager.LoadScene("Map Select"); //방 선택화면 씬 로드
    }
    public void Quiz() //계약사항퀴즈 버튼
    {
        SceneManager.LoadScene("Quiz"); //계약사항퀴즈 씬 로드
    }

    public void RealRoom() //실제방 버튼
    {
        SceneManager.LoadScene("Real Room1");
    }

    public void RealRoom1()
    {
        SceneManager.LoadScene("Real Room Bathroom1");
    }
    public void RealRoom2()
    {
        SceneManager.LoadScene("Real Room Bathroom2");
    }
    public void RealRoom3()
    {
        SceneManager.LoadScene("Real Room Bathroom3");
    }
    public void RealRoom4()
    {
        SceneManager.LoadScene("Real Room Bathroom4");
    }
    public void RealRoomBathroom1() //실제방 화장실 버튼
    {
        SceneManager.LoadScene("Real Room2");
    }
    public void RealRoomBathroom2()
    {
        SceneManager.LoadScene("Real Room3");
    }
    public void RealRoomBathroom3()
    {
        SceneManager.LoadScene("Real Room4");
    }
    public void RealRoomBathroom4() //재시작 버튼
    {
        SceneManager.LoadScene("Restart"); //재시작 씬 로드
    }
}
