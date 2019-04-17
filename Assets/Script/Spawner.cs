using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{//그 장소에 구슬이 없으면 생성
    // Start is called before the first frame update
    public GameObject Blackball;
    public GameObject RedBall;
    public GameObject YellowBall; 
    public GameObject BlueBall; 
    private Vector2[] pos = new Vector2 [4];
    int check = 0;
   // GameObject[] ball;

    GameObject item;
    float timeBtwSpawn;
    private float StartTimeBtwSpawn;
    void Start()
    {
         for (int i = 0; i < 4; i++) {
           GameObject obj = Blackball;
       item = Instantiate(Blackball);//네개 생성
      pos[i].x = -18.7f;
      pos[i].y = 8.7f+(-5.4f * i);
       obj.transform.position = new Vector3(pos[i].x , pos[i].y ,0);

    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어와 충돌");
            if (check == 0)
            {
                Blackball.SetActive(false);
                check++;
                RedBall.SetActive(true);
            }
            else if (check == 0)
            {
                RedBall.SetActive(false);
                YellowBall.SetActive(true);
            }
            else if (check == 1)
            {
                YellowBall.SetActive(false);
                BlueBall.SetActive(true);
            }
            else
            {
                BlueBall.SetActive(false);
                Blackball.SetActive(true);
            }
            
        }
    }

}
