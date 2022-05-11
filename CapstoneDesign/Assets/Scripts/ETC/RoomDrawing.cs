using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomDrawing : MonoBehaviour
{
    private string curSceneName;
    // Start is called before the first frame update
    void Start()
    {
        curSceneName = SceneManager.GetActiveScene().name;

        if (curSceneName == "Room 1 Floor Plan")
        {
            StartCoroutine(Room1());
        }
        else if (curSceneName == "Room 2 Floor Plan")
        {
            StartCoroutine(Room2());
        }
        else if (curSceneName == "Room 3 Floor Plan")
        {
            StartCoroutine(Room3());
        }
        else if (curSceneName == "Room 4 Floor Plan")
        {
            StartCoroutine(Room4());
        }
        else if (curSceneName == "Room 5 Floor Plan")
        {
            StartCoroutine(Room5());
        }
    }

    IEnumerator Room1()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room 1");
    }
    IEnumerator Room2()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room 2");
    }
    IEnumerator Room3()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room 3");
    }
    IEnumerator Room4()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room 4");
    }
    IEnumerator Room5()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room 5");
    }
}
