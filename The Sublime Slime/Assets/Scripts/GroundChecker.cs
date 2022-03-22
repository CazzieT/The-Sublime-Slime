using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem LandingParticals;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            Instantiate(LandingParticals, transform.position, Quaternion.identity);


    }

}