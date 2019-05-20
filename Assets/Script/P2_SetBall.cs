using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_SetBall : MonoBehaviour
{
    public Vector3 pos; //마우스 오른쪽 클릭시 공이 세팅될 위치

    private bool ballTF = false;
    private bool posTF = false; //쏠 공이 자리에 세팅되어 있는지 검사

    void Start()
    {
        pos = new Vector3(8.59f, 5.67f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && posTF == false)  //마우스 오른쪽 버튼 클릭 시
        {
            print("충돌");
           // other.transform.position = pos;
            posTF = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) //other : Collider 사용시 모든 콜리더와 충돌비교
    {
        if (other.CompareTag("passage2"))
        {
            ballTF = true;
        }
    }
}
