using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart;
    //public PlayerLogic player;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            heart.vida--;
            //player.anim.SetTrigger("TakeDamage");
        }
    }
}
