using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    public float smoothing = 1f;
    public bool follow = true;
    public float aheadDistance = 1f;
    private Rigidbody2D playerRigidbody;
    void Start()
    {
        offset = transform.position - player.position;
        playerRigidbody = player.gameObject.GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (!follow || player == null)
            return;

        //Vector3 aheadVector = new Vector3(playerRigidbody.velocity.x, playerRigidbody.velocity.y, 0f);

        Vector3 aheadVector = player.GetComponent<Movement>().facingRight ? Vector3.right : Vector3.left;
        aheadVector += new Vector3(playerRigidbody.velocity.x, 0f, 0f);


        Vector3 newPosition = player.position + (aheadVector * aheadDistance) + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothing * Time.fixedDeltaTime);
    }

}
