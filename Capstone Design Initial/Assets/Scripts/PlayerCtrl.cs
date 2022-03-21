using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Image cursorGauge;
    public GameObject mainCam;
    private float GaugeTimer = 0.0f;
    private float gazeTimer = 2.0f;

    void Update()
    {
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 1000;
        cursorGauge.fillAmount = GaugeTimer;

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            GaugeTimer += 1.0f / gazeTimer * Time.deltaTime;

            if (GaugeTimer >= 1.0f)
            {
                hit.transform.GetComponent<Button>().onClick.Invoke();
                GaugeTimer = 0.0f;
            }
        }
        else
            GaugeTimer = 0.0f;
    }
}
