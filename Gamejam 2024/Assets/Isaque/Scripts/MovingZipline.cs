using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingZipline : MonoBehaviour
{
    public Transform knot, startPoint, endPoint;
    public float speed = .76f;
    BoxCollider2D boxCol2d;

    int direction = 1;

    private void Start()
    {
        boxCol2d = knot.GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        Vector2 target = currentMovementTarget();

        knot.position = Vector2.Lerp(knot.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)knot.position).magnitude;

        if (distance <= 0.1f)
        {
            direction *= -1;
        }

        if(direction == 1)
        {
            boxCol2d.enabled = false;
        }
        if(direction == -1) 
        {
            boxCol2d.enabled = true;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        //Apenas para ser possivel visualizar
        if (knot != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(knot.transform.position, startPoint.position);
            Gizmos.DrawLine(knot.transform.position, endPoint.position);
        }
    }
}
