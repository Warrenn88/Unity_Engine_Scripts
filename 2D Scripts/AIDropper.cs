using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDropper : MonoBehaviour
{
    public float threshold = 3.0f;

    private AIUtility.State state = AIUtility.State.IDLE;
    private GameObject player;
    private Rigidbody2D rigidBody;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (state == AIUtility.State.IDLE)
        {
            float distanceToPlayer = Mathf.Abs(transform.position.x - player.transform.position.x);

            if (distanceToPlayer <= threshold)
            {
                state = AIUtility.State.ATTACKING;
                rigidBody.gravityScale = 1.0f;
            }
        }
    }
}
