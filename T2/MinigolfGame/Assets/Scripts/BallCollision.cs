using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCollision : MonoBehaviour
{
    public float hitForce = 0.01f;
    private Rigidbody rb;

    public int score = 0; 
    public Text scoreText;

    public AudioSource hitSound; 
    private Vector3 initialPosition; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position; 
        UpdateScoreText(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cross"))
        {
            Vector3 forceDirection = transform.position - collision.transform.position;
            rb.AddForce(forceDirection.normalized * hitForce);

            score += 1;
            UpdateScoreText(); 

            if (hitSound != null)
            {
                hitSound.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            transform.position = initialPosition;
            rb.velocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero;
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
