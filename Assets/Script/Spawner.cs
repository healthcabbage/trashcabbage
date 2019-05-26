using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{//그 장소에 구슬이 없으면 생성
    // Start is called before the first frame update
    public GameObject Blackball;
    public GameObject[] ball;
    private Vector2[] pos = new Vector2[4];
    GameObject[] curball = new GameObject[4];
    //private Ball script;


    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            curball[i] = Blackball;
            
            pos[i].x = (-18.7f);
            pos[i].y = 6.8f + (-4.8f * i);   //-7.64
            curball[i].transform.position = new Vector2(pos[i].x,pos[i].y);

          
            Instantiate(curball[i]);//네개 생성         
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
}
