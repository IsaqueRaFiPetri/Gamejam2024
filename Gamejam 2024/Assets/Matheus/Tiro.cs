using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject, 0.25f);
    }
}
