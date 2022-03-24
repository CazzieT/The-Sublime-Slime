using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDes : MonoBehaviour
{
    // Destroys the bullet after 2 sek
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 2);
    }
}
