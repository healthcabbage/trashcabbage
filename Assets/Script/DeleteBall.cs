using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBall : MonoBehaviour
{
    private float timer = 0;
    public float delatTime = 1.0f;
    bool col_trashcan = false;
    bool destroyball = false;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (col_trashcan == true)
        {
            if (Input.GetKeyDown("enter"))
            {

                gameObject.transform.position = pos;
                //gameObject.transform.localScale -= new Vector3(1.0f,1.0f,0.0f);
                destroyball = true;
            }
        }
        if (destroyball == true)
        {
            if(gameObject.transform.localScale.x>0)
            gameObject.transform.localScale -= new Vector3(0.5f, 0.5f, 0.0f);

else
Destroy(gameObject);
            timer += Time.deltaTime;
            if (timer > delatTime)
            {
                timer = 0;
                Destroy(gameObject);
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
