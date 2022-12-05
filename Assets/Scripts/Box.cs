using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start sound effect when box is pushed
    public AudioSource pushSound;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Play sound effect when box is pushed
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bird")
        {
            pushSound.Play();
        }
    }
}
