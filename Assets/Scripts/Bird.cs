using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isPressed = false;

    public bool isReleased = false;

    private Rigidbody2D rb;

    private Rigidbody2D hook;

    public float releaseTime = .15f;

    public float maxDragDistance = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hook = GameObject.Find("Hook").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 mousePosition =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isPressed)
        {
            if (Vector3.Distance(mousePosition, hook.position) > maxDragDistance
            )
            {
                rb.position =
                    (
                    (mousePosition - hook.position).normalized * maxDragDistance
                    ) +
                    hook.position;
            }
            else
            {
                rb.position = mousePosition;
            }
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        isReleased = true;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
    }
}
