using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : LineAnimation
{
    // Used to make the script only work whn the spider is active
    private Animator animator;
    private Sprite spriteSprite;

    private SpriteRenderer spriter;

    //The only layer the player can grapple is decided by the layer
    public LayerMask ropeLayerMask;

    //Distance the raycast can shoot
    public float distance = 90.0f;

    LineRenderer LinerRender;
    DistanceJoint2D rope;

    Vector2 lookDirection;

    // Check if the raycast hits the object with the tag "GrapplingJoint"
    bool checker = true;

    void Start()
    {
        this.enabled = false;

        LinerRender = GetComponent<LineRenderer>();

        rope = GetComponent<DistanceJoint2D>();

        // The grappler begins with the animation off and the distant joint off
        rope.enabled = false;
        LinerRender.enabled = false;
    }

    void Update()
    {
        // the lineAnimation script will reach for the pivior
        if (!LinerRender.enabled)
        {
            piviot.position = transform.position;
        }

        // the lineAnimation script will reach for the pivior
        LinerRender.SetPosition(1, piviot.position);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);


        LinerRender.SetPosition(0, transform.position);

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Debug.DrawLine(transform.position, lookDirection);

        // Input 1 == LMB, 
        if (Input.GetMouseButtonDown(1) && checker == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, distance, ropeLayerMask);

            if (hit.collider != null)
            {
                checker = false;
                SetRope(hit);
            }
        }
        // Press LMB again it will destroy
        else if (Input.GetMouseButtonDown(1) && checker == false)
        {
            checker = true;
            DestroyRope();
        }
    }

    void SetRope(RaycastHit2D hit)
    {
        // 
        rope.enabled = true;
        rope.connectedAnchor = hit.point;

        LinerRender.enabled = true;
        print(hit.point);
        MoveTowardPointStart(hit.point);
    }

    void DestroyRope()
    {
        // Destroys the joint if the user presses LMB when the line is out
        rope.enabled = false;
        LinerRender.enabled = false;
    }

    // Used to swap the sprite and enable GrapplingHook script
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpriteSwap"))
        {
            this.enabled = true;
            // Swaps the sprite when the player touches a sprite with tag SpriteSwap
            animator.SetBool("HasSpider", true);
            spriter.sprite = spriteSprite;
        }
    }
}
