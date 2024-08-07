using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    private float length;
    private float StartPos;
    private Transform cam;
    public float ParallaxEffect;

    int direction = 1;

    void Start()
    {
        /*
        StartPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
        */
    }

    void Update()
    {
        //aplicar a direção que o player está indo para o direction
        //Aplicar movimentação para esse código, na direção oposta do player com o parallax effect agindo como uma velocidade multiplicando o direction
        /*
        float RePos = cam.transform.position.x * (1 - ParallaxEffect);
        float Distance = cam.transform.position.x * ParallaxEffect;
        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z);

        if (RePos > StartPos + length)
        {
            StartPos += length;
        }
        else if (RePos < StartPos - length)
{
            StartPos -= length;
        }
        */
    }
    //https://www.youtube.com/watch?v=1NaWIysHwlk&t=301s
}
