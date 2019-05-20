using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Background : MonoBehaviour
{
    public GameObject[,] item; //게임오브젝트를 통합하는 이름
    //public int itemSize;

    public GameObject[] arrPrefab;

    float span = 3.0f; //span의 값을 초과하면 delta초기화
    float delta = 0;
    int itemPoint = 0; //새로 만들 ball의 배열위치를 표시(y축)
    bool itemTF = true;

    void Start()
    {
        //itemSize = 6;
        //item = new GameObject[itemSize, itemSize];
        item = new GameObject[8, 9];
    }

    void Update()
    {
        if (itemPoint == 8) return; ///줄이 5이 되면 탈출(게임오버조건)
        Debug.Log(itemPoint);

        float px_1 = -2.82f;
        float px_2 = -1.82f;

        if (itemTF == true)
        {
            for (int i = 0; i < 9; i++)
            {

                int color = Random.Range(0, 5); //색 랜덤으로 출력

                item[itemPoint, i] = Instantiate(arrPrefab[color]);

                Vector3 targetPos;
                if (itemPoint % 2 == 0)
                {
                    targetPos = new Vector3(px_1, 11); //출력위치를 받아옴
                    px_1 += (float)2.45;
                }
                else
                {
                    targetPos = new Vector3(px_2, 11); //출력위치를 받아옴
                    px_2 += (float)2.45;
                }
                item[itemPoint, i].transform.position = targetPos;


            }
            itemTF = false;
            itemPoint++;
        }

        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (item[i, j] == null) break;
                    Vector3 originPos = item[i, j].transform.position;
                    item[i, j].transform.position = new Vector3(originPos.x, originPos.y - 2.3f, originPos.z);
                }
            }

            itemTF = true;
        }
    }
}
