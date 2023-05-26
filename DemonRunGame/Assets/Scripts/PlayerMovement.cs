using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;

        if (direction.magnitude > 0)
        {
            animator.SetBool("isWalk", true);

            if (direction.x < 0 && !isFacingRight)
            {
                Flip();
            }
            else if (direction.x > 0 && isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
