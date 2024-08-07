using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    float speed = 5;
    public GameObject tiro;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        Rigidbody2D balaRb = Instantiate(tiro, transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        balaRb.velocity = new Vector2(speed, 0);
        StartCoroutine(Shoot());
    }
}
   