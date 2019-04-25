using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    bool col = false;
    public Sprite[] ball;
    public int check = 0;
    bool reseet = false;
    private float timer = 0;
    public Sprite NextSprite;
    private SpriteRenderer spriteRenderer;
    public float delatTime = 3.0f;
    void Start()
    {

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        NextSprite = ball[1];

        check = 1;

    }

    // Update is called once per frame
    void Update()
    {


        if (col == true)
        {
            if (Input.GetKeyDown("[0]"))
            {
                Change();
                Debug.Log("키누름");
            }
        }

 
        if (reseet == true)
        {
             timer += Time.deltaTime;
            if (timer > delatTime)
            {
                timer += Time.deltaTime;
                spriteRenderer.sprite = NextSprite;
                NextSprite = ball[0];

                spriteRenderer.tag = "black";
                gameObject.name = "black";
                timer = 0;
                check = 0;
                reseet = false;

            }

        }




    }


    void Change()
    {

        if (check == 0)
        {
            spriteRenderer.sprite = NextSprite;
            NextSprite = ball[1];
            spriteRenderer.tag = "black";
            gameObject.name = "black";
            check++;
        }
        else if (check == 1)
        {
            check++;

            spriteRenderer.sprite = NextSprite;
            spriteRenderer.tag = "red";
            gameObject.name = "red";


            NextSprite = ball[2];
        }
        else if (check == 2)
        {
            check++;

            spriteRenderer.sprite = NextSprite;

            spriteRenderer.tag = "yello";
            gameObject.name = "yello";

            NextSprite = ball[3];
        }
        else if (check == 3)
        {
            spriteRenderer.sprite = NextSprite;
            spriteRenderer.tag = "blue";
            gameObject.name = "blue";

            NextSprite = ball[4];
            reseet = false;
            check++;
        }
           else  if (check == 4)
        {
             spriteRenderer.sprite = NextSprite;
             NextSprite = ball[0];
           
            reseet = true;
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
        //input_0 = false;
    }

}
