using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public float Damage = 50f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<health>())
        {
            other.gameObject.GetComponent<health>().TakeDamage(Damage);
        }
    }

}