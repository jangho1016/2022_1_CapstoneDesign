using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public void StartBT()
    {
        SceneManager.LoadScene("Information");
    }

    public void ExitBT()
    {
        Application.Quit();
    }
}
