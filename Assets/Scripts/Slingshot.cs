using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderer;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer[0].positionCount = 2;
        lineRenderer[1].positionCount = 2;
        lineRenderer[0].SetPosition(0, stripPositions[0].position);
        lineRenderer[1].SetPosition(0, stripPositions[1].position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetStrips(){
        SetStrips(idlePosition.position);
    }

    void SetStrips(Vector3 targetPosition){
        lineRenderer[0].SetPosition(1, targetPosition);
        lineRenderer[1].SetPosition(1, targetPosition);
    }
}
