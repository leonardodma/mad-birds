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

    public float maxDragDistance = 5f;

    // Line
    public LineRenderer[] lineRenderer;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hook = GameObject.Find("Hook").GetComponent<Rigidbody2D>();

        // draw
        lineRenderer[0].positionCount = 2;
        lineRenderer[1].positionCount = 2;
        lineRenderer[0].SetPosition(0, stripPositions[0].position);
        lineRenderer[1].SetPosition(0, stripPositions[1].position);

        // reset
        ResetStrips();
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
            SetStrips(rb.position);
        } 

        if (isReleased) {
            // erase line
            lineRenderer[0].positionCount = 0;
            lineRenderer[1].positionCount = 0;

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

    void ResetStrips(){
        SetStrips(idlePosition.position);
    }

    void SetStrips(Vector3 targetPosition){
        lineRenderer[0].SetPosition(1, targetPosition);
        lineRenderer[1].SetPosition(1, targetPosition);
    }
}
