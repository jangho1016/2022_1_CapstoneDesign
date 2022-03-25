using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
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

    public void SelectBT()
    {
        PlayerPrefs.SetInt("SceneNum", 1);
        SceneManager.LoadScene("Room");
    }

    public void ExitBT()
    {
        /*#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif*/
        Application.Quit();
    }
    public void ToBath()
    {
        SceneManager.LoadScene("Real Room1");
    }
}
