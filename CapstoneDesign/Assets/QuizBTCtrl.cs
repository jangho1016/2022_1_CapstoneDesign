using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class QuizBTCtrl : MonoBehaviour
{
    public Button[] bt;
    public Text answer;
    public Text select;
    public Text question;
    public Text cnt;
    public GameObject buttons;

    private void Start()
    {
        PlayerPrefs.SetInt("cnt", 0);

        PlayerPrefs.SetInt("pnf", 0);

        PlayerPrefs.SetInt("chk1", 0);
        PlayerPrefs.SetInt("chk2", 0);
        PlayerPrefs.SetInt("chk3", 0);
        PlayerPrefs.SetInt("chk4", 0);
        PlayerPrefs.SetInt("chk5", 0);

        PlayerPrefs.SetInt("Quiz", 0);

        StartCoroutine(Quiz1());
    }

    private void Update()
    {
        cnt.text = "맞은 문제: " + PlayerPrefs.GetInt("cnt") + "/5";

        if (PlayerPrefs.GetInt("chk1") == 1)
        {
            StartCoroutine(Quiz2());
            PlayerPrefs.SetInt("chk1", 0);
        }
        else if (PlayerPrefs.GetInt("chk2") == 1)
        {
            StartCoroutine(Quiz3());
            PlayerPrefs.SetInt("chk2", 0);
        }
        else if (PlayerPrefs.GetInt("chk3") == 1)
        {
            StartCoroutine(Quiz4());
            PlayerPrefs.SetInt("chk3", 0);
        }
        else if (PlayerPrefs.GetInt("chk4") == 1)
        {
            StartCoroutine(Quiz5());
            PlayerPrefs.SetInt("chk4", 0);
        }

        if(PlayerPrefs.GetInt("pnf") == 1)
        {
            if (PlayerPrefs.GetInt("cnt") == 5)
            {
                SceneManager.LoadScene("Success2");
            }
            else
            {
                SceneManager.LoadScene("Fail2");
            }
        }
        
    }

    public void Bt1()
    {
        if(PlayerPrefs.GetInt("Quiz") == 1)
        {
            StartCoroutine(Wrong1());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 2)
        {
            PlayerPrefs.SetInt("cnt", 2);
            StartCoroutine(Correct2());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 3)
        {
            StartCoroutine(Wrong3());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 4)
        {
            PlayerPrefs.SetInt("cnt", 4);
            StartCoroutine(Correct4());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 5)
        {
            StartCoroutine(Wrong5());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }
    public void Bt2()
    {
        if (PlayerPrefs.GetInt("Quiz") == 1)
        {
            PlayerPrefs.SetInt("cnt", 1);
            StartCoroutine(Correct1());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 2)
        {
            StartCoroutine(Wrong2());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 3)
        {
            StartCoroutine(Wrong3());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 4)
        {
            StartCoroutine(Wrong4());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 5)
        {
            StartCoroutine(Wrong5());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }
    public void Bt3()
    {
        if (PlayerPrefs.GetInt("Quiz") == 1)
        {
            StartCoroutine(Wrong1());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 2)
        {
            StartCoroutine(Wrong2());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 3)
        {
            PlayerPrefs.SetInt("cnt", 3);
            StartCoroutine(Correct3());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 4)
        {
            StartCoroutine(Wrong4());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 5)
        {
            StartCoroutine(Wrong5());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }
    public void Bt4()
    {
        if (PlayerPrefs.GetInt("Quiz") == 1)
        {
            StartCoroutine(Wrong1());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 2)
        {
            StartCoroutine(Wrong2());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 3)
        {
            StartCoroutine(Wrong3());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 4)
        {
            StartCoroutine(Wrong4());
        }
        else if (PlayerPrefs.GetInt("Quiz") == 5)
        {
            PlayerPrefs.SetInt("cnt", 5);
            
            StartCoroutine(Correct5());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }

    IEnumerator Wrong1()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";
        
        answer.DOText("오답입니다1. 틀린 이유는 ~~~~~", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk1", 1);
        
    }

    IEnumerator Wrong2()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("오답입니다2. 틀린 이유는 ~~~~~", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk2", 1);
    }

    IEnumerator Wrong3()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("오답입니다3. 틀린 이유는 ~~~~~", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk3", 1);
    }

    IEnumerator Wrong4()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("오답입니다4. 틀린 이유는 ~~~~~", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk4", 1);
    }

    IEnumerator Wrong5()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("오답입니다5. 틀린 이유는 ~~~~~", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk5", 1);
    }

    IEnumerator Correct1()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다1!", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk1", 1);
    }

    IEnumerator Correct2()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다2", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk2", 1);
    }

    IEnumerator Correct3()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다3!", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk3", 1);
    }

    IEnumerator Correct4()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다1!", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk4", 1);
    }

    IEnumerator Correct5()
    {
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다1!", 2.0f);
        yield return new WaitForSeconds(10.0f);
        answer.text = "";
        yield return new WaitForSeconds(5.0f);
        PlayerPrefs.SetInt("chk5", 1);
    }

    IEnumerator Quiz1()
    {
        PlayerPrefs.SetInt("Quiz", 1);
        select.text = "";
        question.text = "";
        answer.text = "";
        question.DOText("1. 문제 1번입니다\n(1) 답변 1\n(2) 답변 2\n(3) 답변 3\n(4) 답변 4\n\n", 2.0f);
        yield return new WaitForSeconds(2.0f);
        select.DOText("정답을 고르시오", 2.0f);
        yield return new WaitForSeconds(2.0f);

        buttons.transform.localScale = new Vector3(1, 1, 1);
    }
    IEnumerator Quiz2()
    {
        PlayerPrefs.SetInt("Quiz", 2);
        select.text = "";
        question.text = "";
        question.DOText("2. 문제 2번입니다\n(1) 답변 1\n(2) 답변 2\n(3) 답변 3\n(4) 답변 4\n\n", 2.0f);
        yield return new WaitForSeconds(2.0f);
        select.DOText("정답을 고르시오", 2.0f);
        yield return new WaitForSeconds(2.0f);

        buttons.transform.localScale = new Vector3(1, 1, 1);
    }
    IEnumerator Quiz3()
    {
        PlayerPrefs.SetInt("Quiz", 3);
        select.text = "";
        question.text = "";
        question.DOText("3. 문제 3번입니다\n(1) 답변 1\n(2) 답변 2\n(3) 답변 3\n(4) 답변 4\n\n", 2.0f);
        yield return new WaitForSeconds(2.0f);
        select.DOText("정답을 고르시오", 2.0f);
        yield return new WaitForSeconds(2.0f);

        buttons.transform.localScale = new Vector3(1, 1, 1);
    }
    IEnumerator Quiz4()
    {
        PlayerPrefs.SetInt("Quiz", 4);
        select.text = "";
        question.text = "";
        question.DOText("4. 문제 4번입니다\n(1) 답변 1\n(2) 답변 2\n(3) 답변 3\n(4) 답변 4\n\n", 2.0f);
        yield return new WaitForSeconds(2.0f);
        select.DOText("정답을 고르시오", 2.0f);
        yield return new WaitForSeconds(2.0f);
        buttons.transform.localScale = new Vector3(1, 1, 1);
    }
    IEnumerator Quiz5()
    {
        PlayerPrefs.SetInt("Quiz", 5);
        select.text = "";
        question.text = "";
        question.DOText("5. 문제 5번입니다\n(1) 답변 1\n(2) 답변 2\n(3) 답변 3\n(4) 답변 4\n\n", 2.0f);
        yield return new WaitForSeconds(2.0f);
        select.DOText("정답을 고르시오", 2.0f);
        yield return new WaitForSeconds(2.0f);
        buttons.transform.localScale = new Vector3(1, 1, 1);
    }
}
