using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite CurrentSprite; 
    public Sprite NextSprite; 
    private SpriteRenderer spriteRenderer; 
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = CurrentSprite; 
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("플레이어와 충돌");
          
            spriteRenderer.sprite = NextSprite; 

        }
    }
}
