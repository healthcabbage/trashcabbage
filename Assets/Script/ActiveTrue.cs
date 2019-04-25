using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTrue : MonoBehaviour
{
    // Start is called before the first frame update
    Ball ball = GameObject.Find("Ball").GetComponent<Ball>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == false)
            gameObject.SetActive(true);


    }
}
