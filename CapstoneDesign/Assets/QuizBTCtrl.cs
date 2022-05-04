using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizBTCtrl : MonoBehaviour
{

    private void Start()
    {

    }

    public void Bt1()
    {
        if(PlayerPrefs.GetInt("Quiz") == 1)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong1());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 2)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Correct2());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 3)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong3());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 4)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Correct4());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 5)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong5());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 6)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong6());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }
    public void Bt2()
    {
        if (PlayerPrefs.GetInt("Quiz") == 1)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Correct1());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 2)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong2());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 3)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong3());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 4)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong4());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 5)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong5());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 6)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Correct6());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }
    public void Bt3()
    {
        if (PlayerPrefs.GetInt("Quiz") == 1)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong1());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 3)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Correct3());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 4)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong4());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 5)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong5());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 6)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong6());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }
    public void Bt4()
    {
        if (PlayerPrefs.GetInt("Quiz") == 1)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong1());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 3)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong3());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 4)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong4());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 5)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Correct5());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 6)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponent<QuizCtrl>().Wrong6());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }
}
