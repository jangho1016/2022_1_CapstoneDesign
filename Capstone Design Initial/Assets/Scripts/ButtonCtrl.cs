using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public void StartBT()
    {
        PlayerPrefs.SetInt("SceneNum", 1);
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

    public void ExitBT()
    {
        Application.Quit();
    }

    public void SelectBT()
    {
        PlayerPrefs.SetInt("SceneNum", 2);
        SceneManager.LoadScene("Room");
    }
}
