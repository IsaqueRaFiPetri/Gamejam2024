using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image lifeBar;
    public GameObject player;
    PlayerStats stats;

    private void Start()
    {
        SetLife();
        stats = player.GetComponent<PlayerStats>();

    }

    public void SetLife()
    {
        lifeBar.fillAmount = (float)stats.GetLife() / (float)stats.lifeMax;

    }
}
