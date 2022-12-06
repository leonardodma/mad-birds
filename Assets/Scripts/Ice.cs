using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    // Start sound effect when box is pushed
    public float health = 2f;

    public GameObject deathEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > health)
        {
            DestroyBox();
        }
    }

    void DestroyBox()
    {
        Destroy (gameObject);
    }
}
