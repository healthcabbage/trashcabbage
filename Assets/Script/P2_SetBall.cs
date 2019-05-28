using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_SetBall : MonoBehaviour
{
    GameObject ShootBall;
    public Vector3 pos; //마우스 오른쪽 클릭시 공이 세팅될 위치
    private bool usingcol = false; //충돌시 트루반환



    void Start()
    {
        pos = new Vector3(8.59f, -5.47f);
    }

    void Update()
    {      
        if (Input.GetMouseButtonDown(1) && usingcol == true)   //마우스 오른쪽 버튼 클릭 시
        {
            if (usingcol == true) 
            {
                ShootBall.transform.position = pos;
                usingcol = false;
            }

            //  gameObject.GetComponent<P2_SetBall>().enabled = false; //스프라이트종료코드
        }
    }

    void OnTriggerEnter2D(Collider2D other) //other : Collider 사용시 모든 콜리더와 충돌비교
    {
        if (other.gameObject.tag == "Red" || other.gameObject.tag == "Blue" || other.gameObject.tag == "Green" || other.gameObject.tag == "Orange" || other.gameObject.tag == "Pink")
        {
            ShootBall = other.gameObject;
            usingcol = true;
        }
    }
}
