using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameBall : MonoBehaviour
{
    public Vector2[] pos;
    private bool circle;
     private int save = 0;
    //private Vector2[] goal;

    // Start is called before the first frame update
    void Start()
    { 
        pos = new Vector2[6];
        gameObject.GetComponent<FollowBall>().enabled = false;
        
        pos[0] = new Vector2(8.6f, -8.5f);
        pos[1] = new Vector2(5.6f, -8.5f);
        pos[2] = new Vector2(2.6f, -8.5f);
        pos[3] = new Vector2(-1.6f, -8.5f);
        pos[4] = new Vector2(-4.6f, -8.5f);
        pos[5] = new Vector2(-7.6f, -8.5f);
    }
    // Update is called once per frame
    void Update()
    {
         if(circle == true)
        {
            int i = save;
            transform.position = pos[i];
            i++;
            save = i;
            circle = false;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("passage"))
        {
            Debug.Log("통로와 충돌");
            circle = true;
        }
       
    }
}
