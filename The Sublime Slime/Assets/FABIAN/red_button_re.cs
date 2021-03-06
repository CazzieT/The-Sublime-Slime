using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_button_re : MonoBehaviour
{
    private bool prest = false;
    public Animator animator;
    public bool OpenAndClose = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //box pressing button to open door
        Debug.Log("button colides with somthing");
        if (collision.CompareTag("box"))
        {
            Debug.Log("box colides with button");
            prest = true;
            animator.SetTrigger("open");
            Destroy(gameObject);
        }
    }


    //closin door
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!OpenAndClose)
            return;

        if (collision.CompareTag("box"))
        {
            prest = false;
            animator.SetTrigger("close");
            Debug.Log("close");
        }
    }
}

