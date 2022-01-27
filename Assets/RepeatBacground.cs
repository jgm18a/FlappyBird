using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBacground : MonoBehaviour
{
    private BoxCollider2D groundVollider;
    private float groundhorlen; 
    
    void Start()
    {
        groundVollider = GetComponent<BoxCollider2D> ();
        groundhorlen = groundVollider.size.x; 
    }

    
    void Update()
    {
        if (transform.position.x < -groundhorlen)
        {
            MoveBackground();
        }
    }

    private void MoveBackground()
    {
        Vector2 groundOffset = new Vector2 (groundhorlen * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset; 

    }
}
