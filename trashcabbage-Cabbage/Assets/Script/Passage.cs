using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "black")
        {
            Debug.Log("부서짐");
            Destroy(target.gameObject);
        }
        else
        {
            Debug.Log("다른 색 구슬이에옹!");
        }
    }
 

    void Update()
    {
    }

}
