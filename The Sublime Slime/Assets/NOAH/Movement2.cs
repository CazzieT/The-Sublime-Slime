using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    
    public Sprite spriteSprite;

    Rigidbody2D rb;
    public float speed = 5f;
    private Animator animator;
    Vector2 mousePosition;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] public bool facingRight = true;

    // Renders the sprite, allowing you to flip the sprite
    public SpriteRenderer renderer;

    //Vector3 worldPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        renderer.sprite = spriteSprite;
        rb = GetComponent<Rigidbody2D>();

        if (renderer == null)
        {
            Debug.LogError("Player Sprite is missing a renderer");
        }
    }
    void Update()
    {
        // If the character is on the ground you should be able to move else you can move in the air
        if (isGrounded())
        {
            Move();
        }
        else
        {
            AirControl();
        }
        // Dlips the character to a direction by moving the character
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
        // Allows the player to move
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        // DO NOT TOUCH, IGNORE
        //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + moveBy, -10f, 10f), rb.velocity.y);
        //if(isGrounded())
        //rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        //rb.AddForce(new Vector2(moveBy, 0f), ForceMode2D.Force);
    }
    void AirControl()
    {
        // Allows the player to move smoothly in the air 
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + moveBy, -4f, 4f), rb.velocity.y);
    }
    private void Flip()
    {
        // Flips the sprite depending on with way they walk
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
    private bool isGrounded()
    {
        // Checkmis the player is on the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("SpriteSwap"))
        {
            // Swaps the sprite when the player touches a sprite with tag SpriteSwap
            animator.SetBool("HasSpider", true);

            renderer.sprite = spriteSprite;
        }
    }
    
}
