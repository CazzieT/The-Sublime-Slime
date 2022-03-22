using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public float Health = 100f;
    public int deaths = 0;
    public Text deathText;

    //public GameObject deathParticles;
    public void TakeDamage(float damage)
    {
        // if no health
        Health -= damage;
        if (Health <= 0f)
        {
            // If health is zero, one more death to the deathcount. 
            //Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            deaths += 1;
            deathText.text = deaths.ToString();
        }

    }
    // Shows deaths in start of the game
    void Awake()
    {
        deathText.text = deaths.ToString();
    }

}