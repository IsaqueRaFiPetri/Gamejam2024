using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toWin : MonoBehaviour
{
    public Active active;
    bool isColliding;

    private void Start()
    {
        active = FindObjectOfType<Active>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || !isColliding)
        {
            active.isOne = true;
            isColliding = true;
        }
        if (other.CompareTag("Player2") || !isColliding)
        {
            active.isTwo = true;
            isColliding = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || !isColliding)
        {
            active.isOne = true;
            isColliding = true;
        }
        if (collision.CompareTag("Player2") || !isColliding)
        {
            active.isTwo = true;
            isColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            active.isOne = false;
            isColliding = false;
        }
        if (other.CompareTag("Player2"))
        {
            active.isTwo = false;
            isColliding = false;
        }
    }

}
