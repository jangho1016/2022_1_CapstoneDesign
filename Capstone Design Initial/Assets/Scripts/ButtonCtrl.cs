using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonCtrl : MonoBehaviour
{
    int num;

    private void Start()
    {
        num = PlayerPrefs.GetInt("rand_num");
    }

    public void StartBT()
    {
        PlayerPrefs.SetInt("SceneNum", 0);
        SceneManager.LoadScene("Select room");
    }

    public void MainBT()
    {
        PlayerPrefs.SetInt("SceneNum", 0);
        SceneManager.LoadScene("Start Scene");
    }

    public void Information()
    {
        PlayerPrefs.SetInt("SceneNum", 0);
        SceneManager.LoadScene("Information");
    }

    public void SelectBT1()
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

    public void ExitBT()
    {
        Application.Quit();
    }
    public void ToBath()
    {
        SceneManager.LoadScene("Real Room1");
    }
}
