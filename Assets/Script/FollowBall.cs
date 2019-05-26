using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    Vector2 pPos;
    Vector2 _Dir;
    //public double  dis = 1.0f;
    bool col;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Ball>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(col)
        {
            CharMove();
            gameObject.transform.position = pPos + _Dir;            
        }

        if(Input.GetKeyDown("enter"))
         {
             gameObject.GetComponent<SameBall>().enabled = true;
             gameObject.GetComponent<FollowBall>().enabled = false;
        }
    }

      void OnTriggerStay2D(Collider2D other)
    {
         if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어와 충돌");
            col = true;

            pPos = other.transform.position;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("black"))
        {
            gameObject.GetComponent<DeleteBall>().enabled = true;
           // gameObject.GetComponent<FollowBall>().enabled = false;
        }
    }

        void OnTriggerExit2D(Collider2D other)
    {
    col = false;
    }

    void CharMove()
{
     if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _Dir = Vector3.left*2;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _Dir = Vector3.right*2;
        }

        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            _Dir = Vector3.down*2;
        }

        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            _Dir = Vector3.up*2;
        }
        
}

}
