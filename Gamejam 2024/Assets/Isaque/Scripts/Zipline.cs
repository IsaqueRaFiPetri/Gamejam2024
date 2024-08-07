using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zipline : MonoBehaviour
{
    public LineRenderer lineR;
    Transform startPoint, endPoint;

    private void Start()
    {
        lineR = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        //lineR.SetPositions();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            lineR.GetPosition(1);
        }//Faz função no player cujo argumento seja um Vector2 pos da linha. Aqui vc chama essa função usando o colision e nessa função já altera o estado par zipline e lá no estado de zipline aplica o velocity
    }
}
