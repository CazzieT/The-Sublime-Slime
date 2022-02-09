using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPlatform : MonoBehaviour
{
    public float jumpForse = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
        }
    }
}
