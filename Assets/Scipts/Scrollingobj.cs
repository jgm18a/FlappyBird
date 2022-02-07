using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollingobj : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float scrollSpeed = -1.5f;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2 (scrollSpeed,0.0f); 
    }

    
    void Update()
    {
        if (GameController.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
