using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    //public bool is;
    //PlayerLogic player;
    public int vida;
    public int vidaMaxima;
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    void Start()
    {
        //player=GetComponent<PlayerLogic>
    }

    void Update()
    {
        HealthLogic();
        //DeadState();
    }
    void HealthLogic()
    {
        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
        for (int i = 0; i < coracao.Length; i++)
        {
            if (i < vida)
            {
                coracao[i].sprite = cheio;
            }

            else
            {
                coracao[i].sprite = vazio;

                if (i < vidaMaxima)
                {
                    coracao[i].enabled = true;
                }
                else
                {
                    coracao[i].enabled = false;
                }
            }
        }
        //void DeadState()
        {
            if (vida <= 0)
            {
                //isDead = true;
                //GetComponent<PlayerLogic>().enabled = false;
                //PlayerModes.anim.SetBool("isDead", isDead);
                Destroy(gameObject, 1.0f);
            }
        }
    }
}
