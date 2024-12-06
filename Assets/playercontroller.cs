using System;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 10f;

    Rigidbody2D rb;

    public event Action playerDied;

    public AudioSource audioPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("object"))
        {
            // Ensure that playerDied event is invoked
            playerDied?.Invoke();

            // Destroy the player object immediately
            Destroy(this.gameObject);

            // Stop any currently playing sound and play the collision sound right away
            audioPlayer.Stop();    // Stop any current audio if it's playing
            audioPlayer.Play();    // Play the audio immediately
        }
    }
}
