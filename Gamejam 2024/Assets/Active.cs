using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Active : MonoBehaviour
{
    public bool isOne, isTwo;

    private void Update()
    {
        if(isOne && isTwo)
        {
            SceneManager.LoadScene(0);
        }
    }
}
