using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    Rigidbody2D rigid;
    bool input_ = false;
    //Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // if(Input.GetKey(KeyCode.Space))
        // {
        //     if()
        // }
    }
    void OntTriggerEnter(Collider col)
    {
        

    }

    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }

        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            moveVelocity = Vector3.down;
        }

        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            moveVelocity = Vector3.up;
        }



        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }
}
