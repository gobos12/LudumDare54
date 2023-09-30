using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float lerpDuration;
    public float elapsedTime;
    
    public bool targetHit;
    public Transform startPosition;
    public Transform endPosition;
    public float rotationAngle;

    void Start()
    {
        startPosition = null;
        endPosition = null;
        lerpDuration = 0.5f;
        elapsedTime = 0f;
        targetHit = false;
    }
    void Update()
    {
        if (targetHit)
        {
            CameraSlerp(startPosition, endPosition);
        }
    }
    
    
    public void CameraSlerp(Transform start, Transform end)
    {
        if (elapsedTime < lerpDuration)
        {
            transform.position = Vector3.Lerp(start.position, end.position, elapsedTime / lerpDuration);
            transform.rotation = Quaternion.Slerp(start.rotation, Quaternion.Euler(rotationAngle,180,0), elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            targetHit = false;
            elapsedTime = 0;
        }
        
    }
    
    
    
    
    
}
