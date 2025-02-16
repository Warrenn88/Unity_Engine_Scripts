using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private const int SPEED = 8;
    private const int JUMPING_POWER = 8;

    public TMP_Text scoreText;
    public AudioClip jumpingSFX;
    public AudioClip scoreSFX;

    private Rigidbody2D rigidBody;
    private Vector2 movement;

    private bool isJumping;
    private bool isGrounded;

    private AudioSource audioSource;


    private int score;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        isJumping = false;
        score = 0;
    } 

   private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            audioSource.PlayOneShot(jumpingSFX);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(movement * SPEED);

        if (isJumping)
        {
            isJumping = false;
            rigidBody.AddForce(Vector2.up * JUMPING_POWER, ForceMode2D.Impulse);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog")) 
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            audioSource.PlayOneShot(scoreSFX);
            Destroy(collision.gameObject);
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

     private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
