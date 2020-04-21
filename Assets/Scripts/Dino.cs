using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb = null;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float jumpForce = 50f;
    private bool isGrounded = false;
    private float extendedJumpTimeLeft = 0f;
    private float nextIncreaseSpeed = 100f;
    private bool isDead = false;
    private bool alreadyDied = false;
    [SerializeField]
    private GameObject deathParticle = null;
    [SerializeField]
    private GameObject dinoSprite = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isDead = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
    void FixedUpdate()
    {
        if (alreadyDied)
            return;

        if (transform.position.x > nextIncreaseSpeed)
        {
            nextIncreaseSpeed += 200f;
            if (nextIncreaseSpeed > 1000)
                speed *= 1.05f;
            else
                speed *= 1.1f;
        }

        Vector2 vel = new Vector2(speed, rb.velocity.y);

        if (extendedJumpTimeLeft > 0f)
            extendedJumpTimeLeft -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && (isGrounded || extendedJumpTimeLeft > 0f))
        {
            if (!isDead)
                rb.AddForce(new Vector2(0, jumpForce));
            if (isGrounded)
            {
                extendedJumpTimeLeft = 0.14f;
                SoundController.Instance.PlayJumpSound();
            }
        }

        if (!isDead)
            rb.velocity = vel;


        if (isDead)
        {
            SoundController.Instance.PlayDeathSound();
            Master.Instance.OpenDeathPanel();
            Instantiate(deathParticle, transform.position + new Vector3(0, 1, 0), Quaternion.identity, transform);
            dinoSprite.SetActive(false);
            rb.velocity = new Vector2(0, 0);
            alreadyDied = true;
        }

    }

}
