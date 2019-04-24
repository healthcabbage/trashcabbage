using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0.0f;
    public float delaytime = 2.0f;
    bool col = false;
    bool input_0 = false;
    public GameObject[] ball;
    public int check = 0;
    void Start()
    {
        timer = delaytime;
        if (gameObject.tag == "black")
        {
            ball[0] = gameObject;

            for (int i = 1; i < 4; i++)
            {
                Instantiate(ball[i]);

                ball[i].SetActive(true);
                ball[i].transform.position = gameObject.transform.position;
            }
        }
        else if (gameObject.tag == "red")
        {
            ball[1] = gameObject;
        }
        else if (gameObject.tag == "yello")
        { ball[2] = gameObject; }
        else if (gameObject.tag == "blue")
        { ball[3] = gameObject; }


        check = 0;

    }

    // Update is called once per frame
    void Update()
    {


        if (col == true)
        {
            timer += delaytime;
            if (timer > delaytime)
            { input_0 = true; }
            if (input_0 == true)
            {timer = 0;
                if (Input.GetAxisRaw("change") < 0)
                {
                    if (check == 0)
                    {
                        ball[1].SetActive(true);
                        ball[0].SetActive(false);

                        check++;
                        Debug.Log("키누름");
                    }
                    else if (check == 1)
                    {
                        check++;

                        ball[2].SetActive(true);
                        ball[1].SetActive(false);
                    }

                    else if (check == 2)
                    {
                        check++;

                        ball[3].SetActive(true);
                        ball[2].SetActive(false);
                    }
                    else if (check == 3)
                    {
                        check = 0;

                        ball[0].SetActive(true);
                        ball[3].SetActive(false);
                    }
                    input_0 = false;
                }
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어와 충돌");
            col = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        col = false;
        Debug.Log("탈출!");
        timer = 0;
    }
}
