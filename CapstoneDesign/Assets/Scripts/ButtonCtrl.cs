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
            PlayerPrefs.SetInt("rand_num", 0);
            SceneManager.LoadScene("Success1");
        }
        else
        {
            SceneManager.LoadScene("Fail1"); //방 선택 씬 로드
        }
    }

    public void No()
    {
        ManagerPanel = GameObject.FindGameObjectWithTag("ManagerPanel"); //부동산 중개업자 위의 이미지 찾기
        ManagerPanel.gameObject.SetActive(false); //비활성화
    }

    public void ToBath() //실제 화장실 씬으로
    {
        SceneManager.LoadScene("Real Room1"); //화장실 로드
    }

    public void SelectBT1() //값 랜덤 가져와 씬 로드
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room1");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room2");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room3");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room4");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room5");
        }
    }

    public void SelectBT2()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room5");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room1");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room2");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room3");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room4");
        }
    }

    public void SelectBT3()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room4");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room5");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room1");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room2");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room3");
        }
    }

    public void SelectBT4()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room3");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room4");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room5");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room1");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room2");
        }
    }
    public void SelectBT5()
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Room2");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Room3");
        }
        else if (num == 3)
        {
            SceneManager.LoadScene("Room4");
        }
        else if (num == 4)
        {
            SceneManager.LoadScene("Room5");
        }
        else if (num == 5)
        {
            SceneManager.LoadScene("Room1");
        }
    }
    public void RoomSelect()
    {
        SceneManager.LoadScene("Select");
    }
    public void Quiz()
    {
        SceneManager.LoadScene("Quiz");
    }
}
