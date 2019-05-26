using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBall : MonoBehaviour
{
    private float timer = 0;
    public float delatTime = 1.0f;
    bool col_trashcan = false;
    bool destroyball = false;
    int count = 0;
    bool sest = false;
    Vector2 pos;
    // Start is called before the first frame update

    private AudioSource audio;
    public AudioClip breakSound;
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();        
        this.audio.clip = this.breakSound;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (sest == true)
        {
            count++;
            if (count > 200)
                Destroy(gameObject);
        }

        if (col_trashcan == true)
        {
           
            if (Input.GetKeyDown("enter"))
            {
                this.audio.Play();
                gameObject.GetComponent<FollowBall>().enabled = false;
                gameObject.transform.position = pos;
                //gameObject.transform.localScale -= new Vector3(1.0f,1.0f,0.0f);
                destroyball = true;
            }

            if (destroyball == true)
            {
                if (gameObject.transform.localScale.x > 0.5)
                    {
                        gameObject.transform.localScale -= new Vector3(0.5f, 0.5f, 0.0f);
                    sest = true;


                    }
            
                else
                {
                    gameObject.transform.position = new Vector2(-10.7f, 19);
                    
                }
                //timer += Time.deltaTime;
                //if (timer > delatTime)
                //{               
                //    timer = 0;
                //    Destroy(gameObject);
                //}

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("black"))
        {
           
            Debug.Log("쓰레기통 충돌");
            pos = other.gameObject.transform.position;
            
            col_trashcan = true;
        }
    }
}
