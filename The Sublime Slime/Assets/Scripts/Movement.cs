using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    Vector2 mousePosition;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    bool facingRight = true;
    private SpriteRenderer renderer;

    Vector3 worldPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        renderer = GetComponent<SpriteRenderer>();
        if (renderer == null)
        {
            Debug.LogError("Player Sprite is missing a renderer");
        }

    }

    void Update()
    {
        if (isGrounded())
        {
            Move();
        }
        else
        {
            AirControl();
        }


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            renderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            renderer.flipX = true;
        }

        mousePosition = Input.mousePosition;

    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + moveBy, -10f, 10f), rb.velocity.y);
        //if(isGrounded())
        //rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        //rb.AddForce(new Vector2(moveBy, 0f), ForceMode2D.Force);
    }

    void AirControl()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + moveBy, -4f, 4f), rb.velocity.y);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

}