using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSlider : MonoBehaviour
{
    public float patrolDistance = 2.5f;

    public float speed = 3.0f;

    private Rigidbody rb;
   
    private float startX;
    
    private int direction = 1; 

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        startX = transform.position.x;
    }

    void Update ()
    {
        
        if (transform.position.x >= startX + patrolDistance / 2f)
        {
            direction = -1;
        }

        else if (transform.position.x <= startX - patrolDistance / 2f)
        {
            direction = 1;
        }
        
        rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
    }
}
