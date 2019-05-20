﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    bool col = false;
    bool pickup = false;
    public Sprite[] ball;
    public int check = 0;
    bool reseet = false;
    private float timer = 0;
    public Sprite NextSprite;
    private SpriteRenderer spriteRenderer;
    public float delatTime = 3.0f;
    Vector2 pPos;
    private AudioSource audio;
    public AudioClip jumpSound;
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        NextSprite = ball[1];

        check = 1;

        spriteRenderer.tag = "Red";
        gameObject.name = "Red";
        check++;
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
            if (Input.GetKeyDown("enter"))
            {
                PickUpBall();
                pickup = true;
            }
        }
         if (reseet == true)
            {
                timer += Time.deltaTime;
                if (timer > delatTime)
                {
                    spriteRenderer.sprite = NextSprite;
                    NextSprite = ball[0];

                    spriteRenderer.tag = "Red";
                    gameObject.name = "Red";
                    timer = 0;
                    check = 1;
                    reseet = false;

                }
            }

    }

    void PickUpBall()
    {
        //gameObject.transform.position = pPos;
        GameObject packball;
        packball = Instantiate(gameObject);
        packball.transform.position = pPos;
        Debug.Log("픽업");

        packball.gameObject.GetComponent<FollowBall>().enabled = true;

        spriteRenderer.sprite = ball[0];
        spriteRenderer.tag = "Red";
        gameObject.name = "Red";

        NextSprite = ball[1];
        check = 1;

    }

    void Change()
    {
        if (check == 0)
        {
            spriteRenderer.sprite = NextSprite;
            NextSprite = ball[1];
            spriteRenderer.tag = "Red";
            gameObject.name = "Red";
            check = 1;

        }
        else if (check == 1)
        {
            check = 2;

            spriteRenderer.sprite = NextSprite;

            spriteRenderer.tag = "Orange";
            gameObject.name = "Orange";
            this.audio.Play();
            NextSprite = ball[2];
        }
        else if (check == 2)
        {
            this.audio.Play();

            spriteRenderer.sprite = NextSprite;
            spriteRenderer.tag = "Green";
            gameObject.name = "Green";
            check = 3;

            NextSprite = ball[3];
        }
        else if (check == 3)
        {
            spriteRenderer.sprite = NextSprite;
            spriteRenderer.tag = "Blue";
            gameObject.name = "Blue";
            this.audio.Play();
            NextSprite = ball[4];
            //reseet = false;
            check = 4;
        }
        else if (check == 4)
        {
            spriteRenderer.sprite = NextSprite;
            spriteRenderer.tag = "Pink";
            gameObject.name = "Pink";
            NextSprite = ball[5];
            this.audio.Play();
            check = 5;
            // reseet = true;
        }
        else if (check == 5)
        {

            if (reseet == false)
            {
                spriteRenderer.sprite = NextSprite;
                this.audio.Play();
            }
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

            pPos = other.transform.position;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        col = false;
        Debug.Log("탈출!");
        timer= 0;

        //input_0 = false;
    }

}
