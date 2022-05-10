using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirconditionerCtrl : MonoBehaviour
{
    bool isOpen;
    GameObject player; //플레이어
    public GameObject display; //에어컨 디스플레이

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = player.GetComponent<PlayerCtrl>().isOpened[47];

        if (isOpen == true)
        {
            display.GetComponent<MeshRenderer>().materials[0].color = new Color(0.137104f, 0.745283f, 0.169763f); //에어컨 작동시 디스플레이 색상을 초록색으로 바꿔줌
        }
        else if (isOpen == false)
        {
            display.GetComponent<MeshRenderer>().materials[0].color = Color.gray; //에어컨이 작동하지 않을 때 디스플레이 색상을 회색으로 변경
        }
    }
}
