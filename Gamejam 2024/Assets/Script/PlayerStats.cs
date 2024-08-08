using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int lifeMax = 3;
    public int life;

    void Awake()
    {
        life = lifeMax;
    }
    private void Update()
    {
        if (life <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    public int GetLife()
    {
        return life;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("tiro"))
        {
            life -= 1;
        }
    }
}
