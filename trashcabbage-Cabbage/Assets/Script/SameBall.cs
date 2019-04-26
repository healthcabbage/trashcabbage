using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameBall : MonoBehaviour
{
    public GameObject[] arrayObject;
    public int arraySize;
    public bool circle;
    public Vector2 pos;

    private GameObject Instantiate(GameObject gameObject, Vector2 vector2) => throw new NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        arraySize = 7;
        arrayObject = new GameObject[arraySize];
        pos = transform.position = new Vector2(8.55f, -8.64f); //처음 위치 값.
    }
    // Update is called once per frame
    void Update()
    { 
         for (int i = 0; i < arraySize; i++)
          {
            arrayObject[i] = (GameObject)Instantiate(gameObject, pos + new Vector2(-3f, 0f));
          }
        //pos = pos + new Vector2(-3f, 0f);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "passage")
        {
            Debug.Log("통로와 충돌");
            circle = true;
        }
    }
}
