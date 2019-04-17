using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] ball;
    private int check = 0;
    void Start()
    {
        // curBall = Instantiate(Blackball);
        // nextBall = Instantiate(RedBall);
        ball[1].SetActive(false);
        ball[2].SetActive(false);
        ball[3].SetActive(false);

        for(int i = 0; i<4; i++)
        {
            ball[i].transform.position = ball[0].transform.position;
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
                ball[0].SetActive(false);
                check++;
              
                ball[1].SetActive(true);
            }
            else if (check == 0)
            {
                ball[1].SetActive(false);
                check++;
                ball[2].SetActive(true);
            }
            else if (check == 1)
            {
                ball[2].SetActive(false);
                check++;
                ball[3].SetActive(true);
            }
            else
            {
                ball[3].SetActive(false);
                check = 0;
                ball[0].SetActive(true);
            }

        }
    }
}
