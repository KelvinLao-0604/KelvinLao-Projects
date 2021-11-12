using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Star.Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Star.Destroy(gameObject);
    }
}
