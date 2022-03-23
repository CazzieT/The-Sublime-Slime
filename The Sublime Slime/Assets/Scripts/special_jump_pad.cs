using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special_jump_pad : MonoBehaviour
{
    public float jumpForse = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("eye collieds with jump pad");

        if (collision.gameObject.CompareTag("eye"))
        {
            Debug.Log("eye collieds with jump pad");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
        }
    }
}
