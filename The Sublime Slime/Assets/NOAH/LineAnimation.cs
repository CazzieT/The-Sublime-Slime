using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimation : MonoBehaviour
{
    // Creates the Line of the grappling hook making an animation. Basically, creates a line from the player to the piviot thats is attatched to the mosue

    public float speed;

    public Vector2 position;
    public Vector3 worldPosition;
    public Transform piviot;


    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    
    private IEnumerator MoveTowardPoint(Vector2 Position)
    {

        float step = speed * Time.deltaTime;
            
        while(new Vector2(piviot.position.x, piviot.position.y) != Position)
        {
            // Creates an animation that moves toward the piviot
            piviot.position = Vector2.MoveTowards(piviot.position, Position, step);
            yield return new WaitForEndOfFrame();
        }
    }
    public void MoveTowardPointStart(Vector2 Position)
    {
        StartCoroutine(MoveTowardPoint(Position));
    }
}
