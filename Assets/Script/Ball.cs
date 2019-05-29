using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    bool col = false;//플레이어와 충돌
    
    public Sprite[] ball;//공 이미지 받아옴
    public int check = 0;//몇번째 공을 가져야하는지 체크
    bool reseet = false;//마지막 공 두드림 체크
    private float timer = 0;//공 리젠 시간 체크
    public Sprite NextSprite;//다음 공 이미지
    private SpriteRenderer spriteRenderer;
    public float delatTime = 3.0f;//리젠 시간 : 3초
    Vector2 pPos;//플레이어 위치 받아옴
    private AudioSource audio;//오디오를 여기서 받아야할까... 좀 고민해보자
    public AudioClip jumpSound;//두드리면 플레이
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        NextSprite = ball[1];//두번째 공 세팅

        check = 1;//음...

        spriteRenderer.tag = "Red";//시작 태그 : 레드
        gameObject.name = "Red";//시작 이름 : 레드        
    }

    // Update is called once per frame
    void Update()
    {
        if (col == true)//플레이어랑 만났을 때
        {
            if (Input.GetKeyDown("[0]"))//넘버키 0 누름
            {
                Change();//공 바꿈

                Debug.Log("키누름");//이제 없어도 됨
            }
            if (Input.GetKeyDown("enter"))//엔터 누름
            {
                PickUpBall();//공 주기                
            }
        }
         if (reseet == true)//마지막 공 두드림
            {
                timer += Time.deltaTime;//타이머 가동
                if (timer > delatTime)//타이머 다됨
                {
                     
                    spriteRenderer.sprite = NextSprite;//다음 스프라이트로 교환
                    // NextSprite = ball[0];//이거 없어도 되지않아?

                    // spriteRenderer.tag = "Red";//이거도 딱히 여기 없어도 되잖아
                    // gameObject.name = "Red";//
                    timer = 0;
                    check = 1;
                    reseet = false;
                NextSprite = ball[1];//다음 스프라이트 오렌지로 설정
                }
            }

    }

    void PickUpBall()
    {
        //gameObject.transform.position = pPos;
        GameObject packball;//게임 오브젝트 생성
        packball = Instantiate(gameObject);//주기
        packball.transform.position = pPos;//위치 = 플레이어 위치
        Debug.Log("픽업");

        packball.gameObject.GetComponent<FollowBall>().enabled = true;//공 따라가기 준다

        spriteRenderer.sprite = ball[0];//공 초기화
        spriteRenderer.tag = "Red";
        gameObject.name = "Red";

        NextSprite = ball[1];//다음 공 세팅
        check = 1;

    }

    void Change()//넘패드 0 누름
    {
        if (check == 0)//레드
        {
            spriteRenderer.sprite = NextSprite;
            NextSprite = ball[1];
            spriteRenderer.tag = "Red";
            gameObject.name = "Red";
            check = 1;

        }  
        else if (check == 1)//오렌지
        {
            check++;

            spriteRenderer.sprite = NextSprite;//스프라이트 교체

            spriteRenderer.tag = "Orange";//태그 변경
            gameObject.name = "Orange";
            this.audio.Play();
            NextSprite = ball[2];//그린으로
        }
        else if (check == 2)//그린
        {
            this.audio.Play();

            spriteRenderer.sprite = NextSprite;
            spriteRenderer.tag = "Green";
            gameObject.name = "Green";
            check++;

            NextSprite = ball[3];
        }
        else if (check == 3)//블루
        {
            spriteRenderer.sprite = NextSprite;
            spriteRenderer.tag = "Blue";
            gameObject.name = "Blue";
            this.audio.Play();
            NextSprite = ball[4];
            //reseet = false;
            check++;
        }
        else if (check == 4)//핫핑크
        {
            spriteRenderer.sprite = NextSprite;
            spriteRenderer.tag = "Pink";
            gameObject.name = "Pink";
            NextSprite = ball[5];
            this.audio.Play();
            check++;
        }
        else if (check == 5)//마지막공 두드림
        {
            if (reseet == false)//처음 들어왔을때
            {
                spriteRenderer.sprite = NextSprite;
                this.audio.Play();
            }
            
            NextSprite = ball[0];//여기 넣어보자

            spriteRenderer.tag = "Red";
            gameObject.name = "Red";
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
