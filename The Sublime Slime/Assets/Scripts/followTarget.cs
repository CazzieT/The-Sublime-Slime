using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour
{
    public Transform target;
    private Vector2 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(target.position.x + offset.x, target.position.y + offset.y);


    }
    private void Start()
    {
        offset = transform.position - target.position;
    }

}
