using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    public UnityEvent OnUnpause, OnPause;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                OnUnpause.Invoke();
            }
            else
            {
                Time.timeScale = 0;
                OnPause.Invoke();
            }
        }
    }
}
