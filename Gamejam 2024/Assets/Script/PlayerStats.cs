using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int lifeMax = 3;
    public int life;

    void Awake()
    {
        life = lifeMax;
    }
    public int GetLife()
    {
        return life;
    }
}
