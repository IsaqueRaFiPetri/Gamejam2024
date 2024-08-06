using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    public GameObject ladder;
    public Transform startPoint, endPoint;
    public string keyToUse;
    public Rigidbody body;
    public int climbForce;

    bool canClimb;

    private void Start()
    {
        canClimb = false;
    }

    private void Update()
    {
        if(canClimb && Input.GetButtonDown(keyToUse))
        {
            body.AddForce(new Vector2(0, climbForce));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canClimb)
        {
            canClimb = true;
        }
    }
}
