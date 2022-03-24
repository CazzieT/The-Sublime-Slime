using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orange_button_re: MonoBehaviour
{
    private bool prest = false;
    public Animator animator;
    public bool OpenAndClose = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //box pressing button

        if (collision.CompareTag("eye"))
        {

            prest = true;
            animator.SetTrigger("open");
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!OpenAndClose)
            return;

        if (collision.CompareTag("eye"))
        {
            prest = false;
            animator.SetTrigger("close");
            Debug.Log("close");
        }
    }
}

