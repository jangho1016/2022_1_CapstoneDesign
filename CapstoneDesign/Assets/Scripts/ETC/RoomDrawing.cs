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

        if (curSceneName == "Room1 Drawing")
        {
            Debug.Log("test");
            StartCoroutine(Room1());
        }
        else if (curSceneName == "Room2 Drawing")
        {
            StartCoroutine(Room2());
        }
        else if (curSceneName == "Room3 Drawing")
        {
            StartCoroutine(Room3());
        }
        else if (curSceneName == "Room4 Drawing")
        {
            StartCoroutine(Room4());
        }
        else if (curSceneName == "Room5 Drawing")
        {
            StartCoroutine(Room5());
        }
    }

    void Update()
    {
        
    }

    IEnumerator Room1()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room1");
    }
    IEnumerator Room2()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room2");
    }
    IEnumerator Room3()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room3");
    }
    IEnumerator Room4()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room4");
    }
    IEnumerator Room5()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Room5");
    }
}
