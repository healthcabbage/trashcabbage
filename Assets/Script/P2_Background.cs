using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Background : MonoBehaviour
{
    public GameObject Rad; //Rad
    public GameObject Yellow; //Yellow
    public GameObject Blue; //Blue

    float span = 1.0f;
    float delta = 0;
    int[] ballnum = new int[5];

    void Start()
    {

    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta> this.span)
        {
            this.delta = 0;

            GameObject item; //게임오브젝트에 변수명부여
            int color = Random.Range(1, 4); //색 랜덤으로 출력

            if (color == 1)
                item = Instantiate(Rad);
            else if (color == 2)
                item = Instantiate(Yellow);
            else
                item = Instantiate(Blue);

            int px = Random.Range(-7, 8);
            item.transform.position = new Vector3(px, 5, 0); //출력위치 랜덤으로 지정
        }
    }
}
