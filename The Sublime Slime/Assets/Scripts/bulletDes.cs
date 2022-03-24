using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDes : MonoBehaviour
{
    // Destroys the bullet after 2 second
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 2);
    }
}
