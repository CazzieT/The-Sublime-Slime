using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float Health = 100f;
    //public GameObject deathParticles;
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0f)
        {
            //Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            dm.IncreaseDeaths();
        }

    }
    private deathConter dm;

    void Awake()
    {
        dm = GameObject.FindObjectOfType<deathConter>();
    }

}