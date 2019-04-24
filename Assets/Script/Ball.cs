using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    bool col = false;
    bool input_0 = false;
    public GameObject[] ball;
    GameObject next;
    public int check = 0;
    void Start()
    {   
        if (gameObject.tag == "black")
        {
            ball[0] = gameObject;
            next = ball[1];
           /*  for (int i = 1; i < 4; i++)
            {
                Instantiate(ball[i]);

                ball[i].SetActive(false);
                ball[i].transform.position = gameObject.transform.position;
                
            }*/
        }
        else if (gameObject.tag == "red")
        {
            ball[1] = gameObject;
            next = ball[2];
           
        }
        else if (gameObject.tag == "yello")
        {
             ball[2] = gameObject; 
             next = ball[3];
             }

        else if (gameObject.tag == "blue")
        { 
            ball[3] = gameObject; 
            next = ball[0];        
        }

        next.transform.position = gameObject.transform.position;
        check = 0;

    }

    // Update is called once per frame
    void Update()
    {
        next.transform.position = gameObject.transform.position;
        if (col == true)
        {
                if (Input.GetKeyDown("[0]"))
                {
                    

                    next.SetActive(true);
                    gameObject.SetActive(false);

                    Debug.Log("키누름");
                    // if (check == 0)
                    // {
                    //     ball[1].SetActive(true);
                    //     ball[0].SetActive(false);

                    //     check++;
                       
                    // }
                    // else if (check == 1)
                    // {
                    //     check++;

                    //     ball[2].SetActive(true);
                    //     ball[1].SetActive(false);
                    // }
                    // else if (check == 2)
                    // {
                    //     check++;

                    //     ball[3].SetActive(true);
                    //     ball[2].SetActive(false);
                    // }
                    // else if (check == 3)
                    // {
                    //     check = 0;

                    //     ball[0].SetActive(true);
                    //     ball[3].SetActive(false);
                    // }
                   
                
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
       
    }
}
