using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Assign a material to shoot
    public GameObject bullet;

    // Shoots clones from the firepoint
    public Transform firePoint;

    // Change the speed of the bullet
    public float bulletSpeed = 50;

    // Shoots at the direction of the mouse
    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        // Shoots to were the mouse is pointed
        lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        //Allows the user to rotate the firepoint
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            // The firepoint will creat bullet clones to shoot
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
    }
}