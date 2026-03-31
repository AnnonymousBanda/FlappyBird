using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Rigidbody2D player;
    public GameController controller;

    public TextMeshProUGUI scoreText;

    public AudioSource soundWing, soundDeath, soundPoint;

    public float maxY;

    void Start()
    {

    }

    void Update()
    {
        if (GameController.start)
        {
            if (Input.GetMouseButtonDown(0) && transform.position.y < maxY)
            {
                soundWing.Play();

                player.velocity = new Vector2(0f, GameController.velocity * GameController.scalePlayer);
            }

            if (transform.position.y > maxY)
            {
                player.velocity = new Vector2(0f, 0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstructions")
        {
            soundDeath.Play();
            controller.Collision();
        }

        if (other.gameObject.tag == "Points")
        {
            GameController.score++;
            soundPoint.Play();
            scoreText.text = GameController.score.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstructions")
        {
            soundDeath.Play();
            controller.Collision();
        }
    }
}
