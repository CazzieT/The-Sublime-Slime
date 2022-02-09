using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    public float speed = 5f;
    Vector2 mousePosition;

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
        Move();

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
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

}