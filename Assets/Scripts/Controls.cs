using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    bool inAir;
    bool isGrounded;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float a = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(a * speed, rb.velocity.y);

        if (a != 0 && inAir == false)
        {
            animator.SetBool("IsWalking", true);
        }
        else
            animator.SetBool("IsWalking", false);

        if (Input.GetKey(KeyCode.Space) && !inAir)
        {
            inAir = true;
            rb.AddForce(new Vector2(0, 350));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            inAir = false;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            Destroy(gameObject);

        if (collision.gameObject.layer == LayerMask.NameToLayer("Coin"))
            Destroy(collision.gameObject);
    }
}
