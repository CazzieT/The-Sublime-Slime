using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_button : MonoBehaviour
{
    private bool prest = false;
    public Animator animator;
    public bool OpenAndClose = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("box"))
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

        if (GameObject.FindGameObjectWithTag("box"))
        {
            prest = false;
            animator.SetTrigger("close");
            Debug.Log("close");
        }
    }
}

