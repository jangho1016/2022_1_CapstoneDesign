using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class QuizBTCtrl : MonoBehaviour
{
    public Button bt3;
    public Button bt4;
    public Text answer;
    public Text select;
    public Text question;
    public Text cnt;
    public GameObject buttons;
    private AudioSource audioSource;
    public AudioClip correct;
    public AudioClip wrong;

    private void Start()
    {
        PlayerPrefs.SetInt("cnt", 0);
        PlayerPrefs.SetInt("pnf", 0);

        PlayerPrefs.SetInt("chk1", 0);
        PlayerPrefs.SetInt("chk2", 0);
        PlayerPrefs.SetInt("chk3", 0);
        PlayerPrefs.SetInt("chk4", 0);
        PlayerPrefs.SetInt("chk5", 0);
        PlayerPrefs.SetInt("chk6", 0);

        PlayerPrefs.SetInt("Quiz", 0);

        StartCoroutine(Quiz1());
    }

    private void Update()
    {
        cnt.text = "맞은 문제: " + PlayerPrefs.GetInt("cnt") + "/6";

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
        else if (PlayerPrefs.GetInt("chk5") == 1)
        {
            StartCoroutine(Quiz6());
            PlayerPrefs.SetInt("chk5", 0);
        }
        else if(PlayerPrefs.GetInt("chk6") == 1)
        {
            if (PlayerPrefs.GetInt("pnf") == 1)
            {
                if (PlayerPrefs.GetInt("cnt") == 6)
                {
                    SceneManager.LoadScene("Success2");
                }
                else
                {
                    SceneManager.LoadScene("Fail2");
                }
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
        }
        else if (PlayerPrefs.GetInt("Quiz") == 6)
        {
            StartCoroutine(Wrong6());
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
        }
        else if (PlayerPrefs.GetInt("Quiz") == 6)
        {
            PlayerPrefs.SetInt("cnt", 6);
            StartCoroutine(Correct6());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }
    public void Bt3()
    {
        if (PlayerPrefs.GetInt("Quiz") == 1)
        {
            StartCoroutine(Wrong1());
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
        }
        else if (PlayerPrefs.GetInt("Quiz") == 6)
        {
            StartCoroutine(Wrong6());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }
    public void Bt4()
    {
        if (PlayerPrefs.GetInt("Quiz") == 1)
        {
            StartCoroutine(Wrong1());
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
        }
        else if (PlayerPrefs.GetInt("Quiz") == 6)
        {
            StartCoroutine(Wrong6());
            PlayerPrefs.SetInt("pnf", 1);
        }
    }

    IEnumerator Wrong1()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(wrong);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";
        
        answer.DOText("틀렸습니다. 정답은 2번으로 확정일자와 전입 신고는 계약 이후 잔금 일자에 실행하기 때문입니다.\n\n\n\n\n\n\n", 2.0f); //done
        yield return new WaitForSeconds(7.0f);
        answer.text = "";
        PlayerPrefs.SetInt("chk1", 1);
    }

    IEnumerator Wrong2()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(wrong);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("틀렸습니다. 정답은 1번으로 확정일자를 받는 이유는 임차 주택이 경매나 기타 사정으로 위험한 상황이 올 때를 대비하여 우선순위로 보증금을 돌려받기 위함이 맞습니다.\n\n\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(7.0f);
        answer.text = "";
        PlayerPrefs.SetInt("chk2", 1);
    }

    IEnumerator Wrong3()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(wrong);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("틀렸습니다. 정답은 3번으로 등기부등본으로 체납 세금 여부를 상세히 알 수 없기 때문입니다.\n\n\n\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(7.0f);
        answer.text = "";
        PlayerPrefs.SetInt("chk3", 1);
    }

    IEnumerator Wrong4()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(wrong);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("틀렸습니다. 정답은 1번으로 임대차 계약일로부터 30일 이내에 신고해야 합니다.", 2.0f);
        yield return new WaitForSeconds(7.0f);
        answer.text = "";
        PlayerPrefs.SetInt("chk4", 1);
    }

    IEnumerator Wrong5()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(wrong);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("틀렸습니다. 정답은 4번으로 소유자가 다수인 경우 공유물의 관리에 관한 사항에 공유자의 지분의 과반수로 결정한다고 나와있는데 다른 공유자들의 서명을 받지 않은 경우 다른 공유자들이 해당 계약을 무단 관리 행위라 주장하면 해당 계약 체결 행위가 무효가 될 수 있기 때문입니다.\n", 2.0f);
        yield return new WaitForSeconds(7.0f);
        answer.text = "";
        PlayerPrefs.SetInt("chk5", 1);
    }

    IEnumerator Wrong6()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(wrong);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("틀렸습니다. 정답은 2번으로 공인중개사 사무소에서는 확정일자를 받을 수가 없습니다.\n\n\n\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(7.0f);
        answer.text = "";
        PlayerPrefs.SetInt("chk6", 1);
    }

    IEnumerator Correct1()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(correct);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다! 5문제 남았습니다\n\n\n\n\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(3.0f);
        answer.text = "";
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.SetInt("chk1", 1);
    }

    IEnumerator Correct2()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(correct);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다! 4문제 남았습니다\n\n\n\n\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(3.0f);
        answer.text = "";
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.SetInt("chk2", 1);
    }

    IEnumerator Correct3()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(correct);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다! 3문제 남았습니다\n\n\n\n\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(3.0f);
        answer.text = "";
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.SetInt("chk3", 1);
    }

    IEnumerator Correct4()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(correct);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다! 2문제 남았습니다", 2.0f);
        yield return new WaitForSeconds(3.0f);
        answer.text = "";
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.SetInt("chk4", 1);
    }

    IEnumerator Correct5()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(correct);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다! 1문제 남았습니다\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(3.0f);
        answer.text = "";
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.SetInt("chk5", 1);
    }

    IEnumerator Correct6()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource.PlayOneShot(correct);
        buttons.transform.localScale = new Vector3(0, 0, 0);

        select.text = "";

        answer.DOText("정답입니다! 모든 문제를 맞혔습니다!\n\n\n\n\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(3.0f);
        answer.text = "";
        yield return new WaitForSeconds(2.0f);
        PlayerPrefs.SetInt("chk6", 1);
    }

    IEnumerator Quiz1()
    {
        PlayerPrefs.SetInt("Quiz", 1);
        select.text = "";
        question.text = "";
        answer.text = "";
        question.DOText("1. 임대차 계약 시 반드시 확인해야 하는 것이 아닌 것을 고르시오\n(1) 등기부등본\n(2) 확정일자와 전입 신고일자\n(3) 건축물대장\n(4) 임대인\n\n\n\n", 2.0f);
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
        question.DOText("2. 확정일자를 받는 이유는 임차 주택이 경매나 기타 사정으로 위험한 상황이\n올 때를 대비하여 우선순위로 보증금을 돌려받기 위함이다. 보기 중에 옳은 답을 고르시오.\n(1) O\n(2) X\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(2.0f);
        select.DOText("정답을 고르시오", 2.0f);
        yield return new WaitForSeconds(2.0f);

        buttons.transform.localScale = new Vector3(1, 1, 1);
        bt3.gameObject.SetActive(false);
        bt4.gameObject.SetActive(false);
    }
    IEnumerator Quiz3()
    {
        bt3.gameObject.SetActive(true);
        bt4.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Quiz", 3);
        select.text = "";
        question.text = "";
        question.DOText("3. 임대인의 체납 세금 여부를 확인하는 방법으로 옳지 않은 것을 고르시오\n(1) 국세 완납 증명서\n(2) 미납국세 열람 신청\n(3) 등기부등본\n(4) 지방세 완납 증명서\n\n\n\n", 2.0f);
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
        question.DOText("4. 임대차 신고제란 임대차 계약 당사자가 임대료·임대 기간 등의 계약 내용을\n" +
            "신고하도록 하여 임대차 시장 정보를 투명하게 공개하고, 임차인의 권익을\n" +
            "보호하기 위해 도입된 제도이다. 이에 따라 신고 기간 내에 신고하지 않으면\n" +
            "100만 원 이하의 과태료가 부과되는데 다음 보기 중 신고해야 되는 기간으로 옳은 것을 고르시오.\n" +
            "(1) 임대차 계약 체결일로부터 30일 이내\n(2) 임대차 계약 체결일로부터 15일 이내\n" +
            "(3) 임대차 계약 체결일로부터 10일 이내\n(4) 임대차 계약 체결일로부터 60일 이내", 2.0f);
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
        question.DOText("5. 다음 중 임대차계약을 피해야 하는 상황으로 옳은 것을 보기 중에서 고르시오\n(1) 다른 호수의 임대차보증금, 근저당 채권 최고액의 채무액과 본인이 임대차하려는 호수의 보증금의 합계액을 합한 금액이 매매시세의 70%를 넘어가지 않는 경우\n(2) 임대차 하려는 건물이 가등기나 가처분이 설정되지 않은 경우\n(3) 등기부등본에 기재된 집주인 명의와 전세 계약 시 계약자 명의가 동일한 경우\n(4) 소유자가 다수인 경우\n\n", 2.0f);
        yield return new WaitForSeconds(2.0f);
        select.DOText("정답을 고르시오", 2.0f);
        yield return new WaitForSeconds(2.0f);
        buttons.transform.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator Quiz6()
    {
        PlayerPrefs.SetInt("Quiz", 6);
        select.text = "";
        question.text = "";
        question.DOText("6. 확정일자를 발급받는 방법으로 옳지 않은 것을 보기 중에서 고르시오\n(1) 동 주민센터\n(2) 공인중개사 사무소\n(3) 인터넷 등기소 \n(4) 관할 구청\n\n\n\n", 2.0f);
        yield return new WaitForSeconds(2.0f);
        select.DOText("정답을 고르시오", 2.0f);
        yield return new WaitForSeconds(2.0f);
        buttons.transform.localScale = new Vector3(1, 1, 1);
    }
}
