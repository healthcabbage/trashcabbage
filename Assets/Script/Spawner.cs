﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{//그 장소에 구슬이 없으면 생성
    // Start is called before the first frame update
    public GameObject Blackball;    
    private Vector2[] pos = new Vector2[4];
    GameObject item;
    
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Blackball;
            item = Instantiate(Blackball);//네개 생성
            pos[i].x = (-18.7f);
            pos[i].y = 8.7f + (-5.4f * i);
            obj.transform.position = new Vector2(pos[i].x, pos[i].y);
            //obj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if()
        // {

        // }
    }
}
