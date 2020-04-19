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
    private float jumpForce = 100f;
    private bool isGrounded = false;
    private float extendedJumpTimeLeft = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
    void FixedUpdate()
    {
        Vector2 vel = new Vector2(speed, rb.velocity.y);

        if (extendedJumpTimeLeft > 0f)
            extendedJumpTimeLeft -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && (isGrounded || extendedJumpTimeLeft > 0f))
        {
            rb.AddForce(new Vector2(0, jumpForce));
            if (isGrounded)
                extendedJumpTimeLeft = 0.14f;
        }

        rb.velocity = vel;

    }

}
