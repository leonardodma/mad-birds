using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    // Start sound effect when box is pushed
    public AudioSource breakSound;

    public float health = 2f;

    public GameObject deathEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > health)
        {
            // call couritine to destroy box
            StartCoroutine(DestroyBox());
        }
    }

    IEnumerator DestroyBox()
    {
        breakSound.Play();
        Destroy (gameObject);
    }
}
